package cr.ac.tec.mecatec

import android.content.Intent
import android.graphics.Color
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.Gravity
import android.widget.Button
import android.widget.TableLayout
import android.widget.TableRow
import android.widget.TextView
import androidx.core.view.setPadding
import org.json.JSONObject

class Receipt : AppCompatActivity() {
    lateinit var receiptNumList:ArrayList<String>
    lateinit var priceList:ArrayList<String>
    lateinit var detailList:ArrayList<String>

    /**
     * Main function
     */
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_receipt)

        val table = findViewById<TableLayout>(R.id.table)
        val backButton = findViewById<Button>(R.id.btn_back)



        var row:TableRow
        var tvReceipt: TextView
        var tvPrice: TextView
        var tvDetail: TextView

        val user = intent.extras?.getString("user")

        var layoutRow: TableRow.LayoutParams = TableRow.LayoutParams(TableRow.LayoutParams.WRAP_CONTENT,TableRow.LayoutParams.WRAP_CONTENT)
        var layoutReceipt: TableRow.LayoutParams = TableRow.LayoutParams(TableRow.LayoutParams.WRAP_CONTENT,TableRow.LayoutParams.WRAP_CONTENT)
        var layoutPrice: TableRow.LayoutParams = TableRow.LayoutParams(TableRow.LayoutParams.WRAP_CONTENT,TableRow.LayoutParams.WRAP_CONTENT)
        var layoutDetail: TableRow.LayoutParams = TableRow.LayoutParams(TableRow.LayoutParams.WRAP_CONTENT,TableRow.LayoutParams.WRAP_CONTENT)

        val receiptList = JSONObject(FileManager.getReceipts()).getJSONArray(user).length()

        backButton.setOnClickListener {
            val intent = Intent(this, Menu::class.java)
            intent.putExtra("user",user)
            startActivity(intent)
        }

        getReceipts(user.toString())

        for (i in -1..receiptList-1){
            row = TableRow(this)
            row.layoutParams = layoutRow

            if(i == -1){
                tvReceipt = TextView(this)
                tvReceipt.setText("Receipt")
                tvReceipt.gravity = Gravity.CENTER
                tvReceipt.setBackgroundColor(Color.BLACK)
                tvReceipt.setTextColor(Color.WHITE)
                tvReceipt.setPadding(150,10,10,10)
                tvReceipt.layoutParams = layoutReceipt
                row.addView(tvReceipt)



                tvPrice = TextView(this)
                tvPrice.setText("Price")
                tvPrice.gravity = Gravity.CENTER
                tvPrice.setBackgroundColor(Color.BLACK)
                tvPrice.setTextColor(Color.WHITE)
                tvPrice.setPadding(10,10,10,10)
                tvPrice.layoutParams = layoutReceipt
                row.addView(tvPrice)


                tvDetail = TextView(this)
                tvDetail.setText("Detail")
                tvDetail.gravity = Gravity.CENTER
                tvDetail.setBackgroundColor(Color.BLACK)
                tvDetail.setTextColor(Color.WHITE)
                tvDetail.setPadding(10,10,150,10)
                tvDetail.layoutParams = layoutReceipt
                row.addView(tvDetail)


                table.addView(row)

            }else{
                tvReceipt = TextView(this)
                tvReceipt.setText(FileManager.getReceiptsList(i))
                tvReceipt.gravity = Gravity.CENTER
                tvReceipt.setPadding(10,10,10,10)
                tvReceipt.layoutParams = layoutReceipt
                row.addView(tvReceipt)

                tvPrice = TextView(this)
                tvPrice.setText(FileManager.getpriceList(i))
                tvPrice.gravity = Gravity.CENTER
                tvPrice.setPadding(10,10,10,10)
                tvPrice.layoutParams = layoutPrice
                row.addView(tvPrice)

                tvDetail = TextView(this)
                tvDetail.setText(FileManager.getdetailList(i))
                tvDetail.gravity = Gravity.CENTER
                tvDetail.setPadding(10,10,10,10)
                tvDetail.layoutParams = layoutDetail
                row.addView(tvDetail)

                table.addView(row)
            }

        }

    }

    /**
     * Gets the receipts of an user
     */
    fun getReceipts(name:String){

        val receiptList = JSONObject(FileManager.getReceipts()).getJSONArray(name)
        for (i in 0..(receiptList.length()-1)){

            FileManager.setReceiptsList(receiptList.getJSONObject(i).getString("receipt_num"))
            FileManager.setpriceList(receiptList.getJSONObject(i).getString("price"))
            FileManager.sepdetailList(receiptList.getJSONObject(i).getString("detail"))

        }

    }

}