package cr.ac.tec.mecatec

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import org.json.JSONObject

class Receipt : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_receipt)

        val user = intent.extras?.getString("user")
        if(validation(user.toString())){
            getReceipts(user.toString())

        }
    }


    fun validation(name:String): Boolean{
//        val data = JSONObject(loadData("Receipts.json"))
        if (JSONObject(FileManager.getReceipts()).has(name)){
            return true
        }
        return false
    }

    fun getReceipts(name:String){

        val receiptList = JSONObject(FileManager.getReceipts()).getJSONArray(name)
        for (i in 0..(receiptList.length()-1)){
            println(receiptList.getJSONObject(i).getString("detail"))


        }


    }
}