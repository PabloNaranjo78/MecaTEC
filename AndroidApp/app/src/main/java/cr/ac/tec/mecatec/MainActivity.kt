package cr.ac.tec.mecatec

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.TextView
import androidx.appcompat.app.AlertDialog
import org.json.JSONObject
import java.io.IOException

class MainActivity : AppCompatActivity() {

    /**
     * Main function
     */
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)


        val userText = findViewById<TextView>(R.id.edt_user)
        val passText = findViewById<TextView>(R.id.edt_password)
        val loginButton = findViewById<Button>(R.id.btn_login)

        loadFiles()



        loginButton.setOnClickListener {

            val user = userText.text.toString()
            val password = passText.text.toString()

            if (validation(user, password)){
                val intent = Intent(this, Menu::class.java)
                intent.putExtra("user",user)
                startActivity(intent)

            }else{

                val alertDialogBuilder = AlertDialog.Builder(this)
                alertDialogBuilder.setTitle("War ")
                alertDialogBuilder.setMessage("Your user name or password is incorrect." + "\n" +"Please try again.")
                alertDialogBuilder.setPositiveButton("OK",null)
                alertDialogBuilder.show()


            }

        }

    }

    /**
     * Load .json files to an specific class
     */
    fun loadFiles(){
        FileManager.setUsers(loadData("Users.json"))
        FileManager.setReceipts(loadData("Receipts.json"))
        FileManager.setAppointments(loadData("Appointments.json"))
    }

    /**@param inFile file to be read
     * @return information inside the file
     *
     */
    fun loadData(inFile: String): String {
        var tContents = ""
        try{
            val stream = assets.open(inFile)
            val size = stream.available()
            val buffer = ByteArray(size)
            stream.read(buffer)
            stream.close()
            tContents =  String(buffer)
        }catch (e: IOException){
        }
        return tContents
    }

    /**@param name user name
     * @param password user password
     * Check if the user and password are correct
     */
    fun validation(name:String, password:String): Boolean{
        if (JSONObject(FileManager.getUsers()).has(name)){
            if (JSONObject(FileManager.getUsers()).getJSONObject(name).getString("pass") == password){
                return true
            }
            return false
        }else{
            return false
        }


    }
}