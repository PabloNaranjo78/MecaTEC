package cr.ac.tec.mecatec

import android.app.Activity
import android.content.Intent
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
    /**
     * Main function
     */
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_customer)

        val user = intent.extras?.getString("user")
        val saveButton = findViewById<Button>(R.id.btn_save)
        val cancelButton =  findViewById<Button>(R.id.btn_cancelCustomer)
        val passText = findViewById<TextView>(R.id.edt_newpass)

        findViewById<TextView>(R.id.pt_user).setText(user)
        findViewById<TextView>(R.id.pt_lastNameCustumer).setText(JSONObject(FileManager.getUsers()).getJSONObject(user).get("lastNames").toString())
        findViewById<TextView>(R.id.pt_phoneCustumer).setText(JSONObject(FileManager.getUsers()).getJSONObject(user).get("phone").toString())
        findViewById<TextView>(R.id.pt_idCustumer).setText(JSONObject(FileManager.getUsers()).getJSONObject(user).get("id").toString())
        findViewById<TextView>(R.id.pt_emailCustumer).setText(JSONObject(FileManager.getUsers()).getJSONObject(user).get("email").toString())
        findViewById<TextView>(R.id.pt_addressCustumer).setText(JSONObject(FileManager.getUsers()).getJSONObject(user).get("address").toString())

        saveButton.setOnClickListener {
            if (passText.text.toString() != ""){
                changePassword(user.toString(),passText.text.toString())

            }else{
                println("Type a valid password")
            }

        }

        cancelButton.setOnClickListener {
            val intent = Intent(this, Menu::class.java)
            intent.putExtra("user",user)
            startActivity(intent)
        }


    }

    /**@param name user name
     * @param password new password
     * Change the user password
     */
    fun changePassword(name:String, password:String){
        val data = JSONObject(FileManager.getUsers())
        val userData = data.getJSONObject(name)
        userData.put("pass",password)
        data.put(name, userData)


        FileManager.setUsers(data.toString())
        println(FileManager.getUsers())

        val alertDialogBuilder = AlertDialog.Builder(this)
        alertDialogBuilder.setTitle("Warming")
        alertDialogBuilder.setMessage("Your password have been changed")
        alertDialogBuilder.setPositiveButton("OK",null)
        alertDialogBuilder.show()

    }


}