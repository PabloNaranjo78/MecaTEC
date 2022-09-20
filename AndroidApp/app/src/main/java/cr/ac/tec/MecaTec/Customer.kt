package cr.ac.tec.mecatec

import android.app.Activity
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import androidx.appcompat.app.AlertDialog
import org.json.JSONObject
import java.io.*
import java.util.*
import java.util.Properties

import javax.mail.Message
import javax.mail.MessagingException
import javax.mail.PasswordAuthentication
import javax.mail.Session
import javax.mail.Transport
import javax.mail.internet.InternetAddress
import javax.mail.internet.MimeMessage






class Customer : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_customer)

        val user = intent.extras?.getString("user")
        val saveButton = findViewById<Button>(R.id.btn_save)
        val passText = findViewById<TextView>(R.id.edt_newpass)

        findViewById<TextView>(R.id.pt_user).setText(user)

        saveButton.setOnClickListener {
            if (passText.text.toString() != ""){
                changePassword(user.toString(),passText.text.toString())

            }else{
                println("Type a valid password")
            }

        }


    }
    fun changePassword(name:String, password:String){
        val data = JSONObject(loadData("Users.json"))
        val userData = data.getJSONObject(name)
        println(userData.getString("pass"))
        userData.put("pass",password)
        data.put(name, userData)



        FileManager.setUsers(data.toString())
        println(FileManager.getUsers())



        val alertDialogBuilder = AlertDialog.Builder(this)
        alertDialogBuilder.setTitle("Warming")
        alertDialogBuilder.setMessage("Your password have been changed, check your email for more information")
        alertDialogBuilder.setPositiveButton("OK",null)
        alertDialogBuilder.show()


    }


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

    fun sendPassword(address: String, info: String){
        val mail = "mecatec.info@gmail.com"
        val pass = "Mecatec123"
        val props = Properties()

        props.put("mail.smtp.auth","true")
        props.put("mail.smtp.starttls.enable","true")
        props.put("mail.smtp.host","smtp.gmail.com")
        props.put("mail.smtp.port","587")

        val aux =  PasswordAuthentication(mail, pass)



        val session = Session.getInstance(props,)

    }

    fun setFileInstance(){

    }

//    class derived : PasswordAuthentication() {
//        override fun PasswordAuthentication
//    }

}