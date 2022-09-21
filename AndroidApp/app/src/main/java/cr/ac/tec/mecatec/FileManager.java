package cr.ac.tec.mecatec;

import androidx.appcompat.app.AppCompatActivity;




import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Context;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.util.LinkedList;
import java.util.Scanner;
import java.util.Vector;


public class FileManager {

    static String users ;
    static String receipts;
    static String appointments;
    static LinkedList receiptsList = new LinkedList();
    static LinkedList priceList = new LinkedList();
    static LinkedList detailList = new LinkedList();

    /**
     * Return a receipt number
     * @param poss poss in list
     * @return receipt number
     */
    public static String getReceiptsList(int poss) {
        return (String) receiptsList.get(poss);
    }

    /**
     * Add a new receipt
     * @param value value to be added
     */
    public static void setReceiptsList(String value) {
        receiptsList.add(value);
    }

    /**
     * Return the price of a receipt
     * @param poss poss in list
     * @return price value
     */
    public static String getpriceList(int poss) {
        return (String) priceList.get(poss);
    }

    /**
     * Add a new receipt
     * @param value value to be added
     */
    public static void setpriceList(String value) {
        priceList.add(value);
    }

    /**
     * Return the detail of a receipt
     * @param poss poss in list
     * @return detail
     */
    public static String getdetailList(int poss) {
        return (String) detailList.get(poss);
    }

    /**
     * Add a new detail
     * @param value value to be added
     */
    public static void sepdetailList(String value) {
        detailList.add(value);
    }

    /**
     * Return the appointments of a user
     * @return detail
     */
    public static String getAppointments() {
        return appointments;
    }

    /**
     * Add a new appointment
     * @param appointments value to be added
     */
    public static void setAppointments(String appointments) {
        FileManager.appointments = appointments;

    }

    /**
     * Get receipts of a user
     * @return receipts
     */
    public static String getReceipts() {
        return receipts;
    }

    /**+
     * Add a new receipt
     * @param receipts receipt
     */
    public static void setReceipts(String receipts) {
        FileManager.receipts = receipts;
    }

    /**
     * Add users
     * @param data user name
     */
    public static void setUsers(String data){

        FileManager.users = data;
    }

    /**
     * Get user
     * @return user
     */
    public static String getUsers(){
        return users;
    }

    /**
     * Resets the lists
     */
    public static void reset(){
        receiptsList = null;
        priceList = null;
        detailList = null;

    }

}
