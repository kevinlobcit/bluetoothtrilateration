package com.example.bluetoothappk

import android.Manifest
import android.app.Activity
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle

import android.bluetooth.BluetoothAdapter
import android.bluetooth.BluetoothManager
import android.bluetooth.le.ScanCallback
import android.bluetooth.le.ScanResult
import android.content.Intent
import android.content.pm.PackageManager
import android.os.Build
import android.os.Handler
import android.util.Log
import android.widget.Button
import android.widget.Toast
import androidx.activity.result.contract.ActivityResultContracts
import androidx.core.app.ActivityCompat

//https://www.geeksforgeeks.org/how-to-make-bluetooth-discoverable-to-other-devices-in-android/

class MainActivity : AppCompatActivity() {


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        //declare the buttons
        val btnOn = findViewById<Button>(R.id.btnOn)
        val btnOff = findViewById<Button>(R.id.btnOFF)
        val btnDisc = findViewById<Button>(R.id.btnDiscoverable)

        //https://stackoverflow.com/questions/68095709/startactivityforresult-is-deprecated-and-unable-to-request-for-bluetooth-connec
        var requestBluetooth = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) { result ->
            if (result.resultCode == RESULT_OK) {
                //granted
                Toast.makeText(applicationContext, "Bluetooth is granted", Toast.LENGTH_SHORT).show()
            }else{
                //deny
            }
        }
        val requestMultiplePermissions = registerForActivityResult(ActivityResultContracts.RequestMultiplePermissions()) { permissions ->
            permissions.entries.forEach {
                Log.d("test006", "${it.key} = ${it.value}")
            }
            Toast.makeText(applicationContext, "Bluetooth is granted", Toast.LENGTH_SHORT).show()
        }

        var requestDiscoverable = registerForActivityResult(ActivityResultContracts.StartActivityForResult()) { result ->
            if (result.resultCode == RESULT_OK) {
                //granted
                Toast.makeText(applicationContext, "Bluetooth discoverability is granted", Toast.LENGTH_SHORT).show()
            }else{
                //deny
            }
        }



        //start the bluetooth adapter
        //https://developer.android.com/guide/topics/connectivity/bluetooth/setup#kotlin
        val btManager:BluetoothManager = getSystemService(BluetoothManager::class.java)
        val btAdapter:BluetoothAdapter?= btManager.getAdapter()

        val btLeScanner = btAdapter?.bluetoothLeScanner
        var scanning = false
        //val handler = Handler()
        val SCAN_PERIOD: Long = 10000

        //stop scanning after 10 seconds
        //val leDeviceListAdapter = LeDeviceListAdapter()
        val leScanCallback: ScanCallback = object : ScanCallback() {
            override fun onScanResult(callbackType: Int, result: ScanResult) {
                super.onScanResult(callbackType, result)
                //leDeviceListAdapter.addDevice(result.device)
                //leDeviceListAdapter.notifyDataSetChanged()
            }
        }



        btnOn.setOnClickListener() {
            if (btAdapter == null) {
                //device doesnt support bluetooth
                Toast.makeText(applicationContext, "Bluetooth not supported", Toast.LENGTH_SHORT).show()
            } else {
                if (!btAdapter.isEnabled) {
                    //request permission to use and turn on bluetooth
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.S) {
                        requestMultiplePermissions.launch(arrayOf(
                            Manifest.permission.BLUETOOTH_SCAN,
                            Manifest.permission.BLUETOOTH_CONNECT))
                    }
                    //turn on bluetooth
                    val enableBtIntent = Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE)
                    requestBluetooth.launch(enableBtIntent)

                } else {
                    Toast.makeText(applicationContext, "Bluetooth is already turned on", Toast.LENGTH_SHORT).show()
                }
            }
        }

        btnOff.setOnClickListener{
            if(btAdapter == null) {
                //device doesnt support bluetooth
                Toast.makeText(applicationContext, "Bluetooth not supported", Toast.LENGTH_SHORT).show()
            } else {
                if(btAdapter.isEnabled) {
                    //turn off the bluetooth
                    if (ActivityCompat.checkSelfPermission(this, Manifest.permission.BLUETOOTH_CONNECT
                        ) != PackageManager.PERMISSION_GRANTED
                    ) {} else {
                        btAdapter.disable()
                    }

                }
            }
            Toast.makeText(applicationContext, "Bluetooth turned off", Toast.LENGTH_SHORT).show()
        }

        btnDisc.setOnClickListener{
            Toast.makeText(applicationContext, "check1", Toast.LENGTH_SHORT).show()
            if(!btAdapter!!.isDiscovering){
                //need to make discoverability last forever or whenever user wants to turn it off
                val enableDiscoverIntent = Intent(BluetoothAdapter.ACTION_REQUEST_DISCOVERABLE)
                requestDiscoverable.launch(enableDiscoverIntent)
                Toast.makeText(applicationContext, "Making Device Discoverable", Toast.LENGTH_SHORT).show()
            }
            else{
                Toast.makeText(applicationContext, "failed", Toast.LENGTH_SHORT).show()
            }
        }


    }

}