package cr.ac.tec.mecatec

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button

class Menu : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_menu)

        val user = intent.extras?.getString("user")

        val profileButton = findViewById<Button>(R.id.btn_edtProfile)
        val appointmentButton = findViewById<Button>(R.id.btn_mkAppointment)
        val receiptsButton = findViewById<Button>(R.id.btn_receipts)

        profileButton.setOnClickListener{
            val intent = Intent(this, Customer::class.java)
            intent.putExtra("user",user)
            startActivity(intent)
        }

        appointmentButton.setOnClickListener{
            val intent = Intent(this, Appointment::class.java)
            intent.putExtra("user",user)
            startActivity(intent)
        }

        receiptsButton.setOnClickListener{
            val intent = Intent(this, Receipt::class.java)
            intent.putExtra("user",user)
            startActivity(intent)
        }


    }
}