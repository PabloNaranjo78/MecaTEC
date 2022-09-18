package cr.ac.tec.mecatec

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import org.json.JSONObject
import java.io.IOException

class Receipt : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_receipt)

        val user = intent.extras?.getString("user")
    }


    fun validation(name:String): Boolean{
//        val data = JSONObject(loadData("Receipts.json"))
        if (JSONObject(loadData("Receipts.json")).has(name)){
            return true
        }
        return false
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
}