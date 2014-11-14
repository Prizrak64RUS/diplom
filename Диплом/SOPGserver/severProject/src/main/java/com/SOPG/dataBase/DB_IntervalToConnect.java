/**
 * 
 */
package com.SOPG.dataBase;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

/**
 * @author vladimir
 * 
 */
public class DB_IntervalToConnect extends DB_Conn {
	private static String queryToDataConnect = "SELECT CONCAT( 'jdbc:mysql://',(SELECT `value` FROM call_centr_db.system WHERE    parametr LIKE 'server_db_ip'),':',"
										+ "(SELECT `value` FROM call_centr_db.system WHERE    parametr LIKE 'server_db_port'),'/',"
										+ "(SELECT `value` FROM call_centr_db.system WHERE    parametr LIKE 'server_db_name')),"
									+ "(SELECT `value` FROM call_centr_db.system  WHERE    parametr LIKE 'server_db_login'),"
									+ "(SELECT `value` FROM call_centr_db.system  WHERE    parametr LIKE 'server_db_pass'),"
									+ "(SELECT `value` FROM call_centr_db.system  WHERE    parametr LIKE 'server_db_table');";
	
	private static String queryIp = "SELECT `value` FROM call_centr_db.system WHERE    parametr LIKE 'server_db_ip'";
	private static ArrayList<String> dataToDB=null;
	private static String driver = "com.mysql.jdbc.Driver";
	private static String ip;
	/**
	 * 
	 */
	public  DB_IntervalToConnect() {
		// TODO Auto-generated constructor stub
	}
	
	/*
	 * @return connect
	 */
	public static Connection getConnection() {
		if (dataToDB == null) {
			dataToDB = getConnectionData();
		}
		Connection	connect = connection();
		return connect;
	}
	
	/*
	 * @return ip
	 */
	public static String getIp(){
		if (ip == null) {
			DB_IntervalToConnect dbClass = new DB_IntervalToConnect();
			Connection connect = dbClass.getConn();
			ArrayList<String> dataToDB = new ArrayList<String>();
			try {
				Statement select = connect.createStatement();
				ResultSet result = select.executeQuery(queryIp);
				while (result.next()) {
					ip=result.getString(1);
				}
				result.close();
				connect.close();
				} 
			catch (SQLException e) {
				System.err.println("Mysql Statement Error: " + queryIp);
				//ip=ReaderDataToConnectDB.getData(TypeToVariable.MAIL_IP.getName());
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		return ip;
		
	}
	/*
	 * @return connect
	 */
	private static Connection connection() {
		String url = dataToDB.get(0);
		String user = dataToDB.get(1);
		String pass = dataToDB.get(2);
		Connection connect=null;
		try {
			Class.forName(driver).newInstance();
			DriverManager.setLoginTimeout(120);
			connect = DriverManager.getConnection(url, user, pass);

		} catch (Exception e) {
			// error
			System.err.println("Mysql Connection Error: ");
			System.err.println("Incorrect username and password, or connect string to side bd.");
			System.err.println("~~~~~~~~~~ can't get a Mysql connection");
			connect=null;
			// for debugging error
			e.printStackTrace();
		}
		return connect;
		//return connect;
	}

	/*
	 * @return ConnectionData
	 */
	protected static ArrayList<String> getConnectionData() {

		DB_IntervalToConnect dbClass = new DB_IntervalToConnect();
		Connection connect = dbClass.getConn();
		ArrayList<String> dataToDB = new ArrayList<String>();
		try {
			Statement select = connect.createStatement();
			ResultSet result = select.executeQuery(queryToDataConnect);
			while (result.next()) {
				dataToDB.add(result.getString(1));
				dataToDB.add(result.getString(2));
				dataToDB.add(result.getString(3));
				dataToDB.add(result.getString(4));
			}
			result.close();
			connect.close();
			} catch (SQLException e) {
			System.err.println("Mysql Statement Error: " + queryToDataConnect);
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return dataToDB;
	}
}
