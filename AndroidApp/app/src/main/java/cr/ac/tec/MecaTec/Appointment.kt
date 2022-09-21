package cr.ac.tec.mecatec

import android.content.Intent
import android.os.Build
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.*
import androidx.annotation.RequiresApi
import androidx.appcompat.app.AlertDialog
import org.json.JSONObject
import java.time.LocalDateTime
import java.time.Year
import java.util.*

class Appointment : AppCompatActivity() {

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_appointment)

        val user = intent.extras?.getString("user").toString()
        val licensePlate = findViewById<TextView>(R.id.edt_licensePlate)
        val spSubsidiary = findViewById<Spinner>(R.id.sp_subsidiary)
        val spServices =  findViewById<Spinner>(R.id.sp_services)
        val saveButton = findViewById<Button>(R.id.btn_saveAppointment)
        val cancelButton = findViewById<Button>(R.id.btn_cancelAppointment)
        val picker = findViewById<DatePicker>(R.id.date_picker)
        val subsidiaries = listOf("San Francisco", "Los Angeles", "New York")
        val services = listOf("Oil Change", "New Tint", "Engine Change")

        var selectedService = ""
        var selectedSubsidiary = ""

        findViewById<TextView>(R.id.tv_userAppointment).setText(user)

        spSubsidiary.adapter = ArrayAdapter(this,android.R.layout.simple_spinner_item, subsidiaries)
        spServices.adapter = ArrayAdapter(this,android.R.layout.simple_spinner_item, services)

        spServices.onItemSelectedListener = object :
            AdapterView.OnItemSelectedListener{
            override fun onItemSelected(p0: AdapterView<*>?, p1: View?, p2: Int, p3: Long) {
                selectedService = services[p2]
            }

            override fun onNothingSelected(p0: AdapterView<*>?) {
                TODO("Not yet implemented")
            }

        }

        spSubsidiary.onItemSelectedListener = object :
            AdapterView.OnItemSelectedListener{
            override fun onItemSelected(p0: AdapterView<*>?, p1: View?, p2: Int, p3: Long) {
                selectedSubsidiary =subsidiaries[p2]
            }

            override fun onNothingSelected(p0: AdapterView<*>?) {
                TODO("Not yet implemented")
            }

        }

        saveButton.setOnClickListener {
            if (licensePlate.text.toString() != "" && checkDate(picker.dayOfMonth,(picker.month+1),picker.year)){
                val data = JSONObject(FileManager.getAppointments())
                val myAppointments = data.getJSONArray(user)
                val newData = JSONObject("{\"licensePlate\": \"${licensePlate.text}\"," +
                        " \"subsidiary\": \"$selectedSubsidiary\", \"service\": \"$selectedService\"," +
                        " \"date\":\"${getDate(picker.dayOfMonth.toString(),(picker.month+1).toString(),
                            picker.year.toString())}\"}")

                myAppointments.put(newData)
                data.put(user,myAppointments)
                FileManager.setAppointments(data.toString())

                val alertDialogBuilder = AlertDialog.Builder(this)
                alertDialogBuilder.setTitle("Warming")
                alertDialogBuilder.setMessage("You have registered a new appointment.")
                alertDialogBuilder.setPositiveButton("OK",null)
                alertDialogBuilder.show()


            }else{
                val alertDialogBuilder = AlertDialog.Builder(this)
                alertDialogBuilder.setTitle("Warming ")
                alertDialogBuilder.setMessage("Please check your license plate or the appointment date.")
                alertDialogBuilder.setPositiveButton("OK",null)
                alertDialogBuilder.show()
            }

        }

        cancelButton.setOnClickListener {
            val intent = Intent(this, Menu::class.java)
            intent.putExtra("user",user)
            startActivity(intent)
        }

    }

    /**
     * Marges the date
     *@param day selected
     * @param month selected
     * @param year selected
     */
    fun getDate(day:String, month:String, year: String): String{
        return "$day/$month/$year"
    }

    /**
     * Checks is the date is valid
     */
    @RequiresApi(Build.VERSION_CODES.O)
    fun checkDate(day: Int, month: Int, year: Int): Boolean{
        val today = LocalDateTime.now()

        if(year>today.year){
            return true
        }else if(year==today.year){
            if (month > today.monthValue){
                return true
            }else if(month == today.monthValue){
                if(day >= today.dayOfMonth){
                    return true
                }
            }
        }
        return false

    }
}