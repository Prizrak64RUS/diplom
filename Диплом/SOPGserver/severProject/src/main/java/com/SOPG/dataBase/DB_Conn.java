package com.SOPG.dataBase;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;


public abstract class DB_Conn {
	
	protected static String driver = "com.mysql.jdbc.Driver";
	
	protected Connection getConn() {
		Connection conn	= null;
		String url	=ReaderDataToConnectDB.getData(TypeToVariable.DB_URL.getName());
		String user =ReaderDataToConnectDB.getData(TypeToVariable.DB_LOGIN.getName());
		String pass =ReaderDataToConnectDB.getData(TypeToVariable.DB_PASSWORD.getName());
		
		try {
			Class.forName(driver).newInstance();
			DriverManager.setLoginTimeout(120);
			conn = DriverManager.getConnection(url, user, pass);

		} 
		catch (Exception e) {
			ReaderDataToConnectDB.reRead();
			// error
			System.err.println("Mysql Connection Error: ");
			System.err.println("Incorrect username and password, or connect string to header bd.");
			System.err.println("~~~~~~~~~~ can't get a Mysql connection");
			conn=null;
			// for debugging error
			e.printStackTrace();
		}
		return conn;
	}

	protected static int getResultSetSize(ResultSet resultSet) {
		int size = -1;
		try {
			resultSet.last();
			size = resultSet.getRow();
			resultSet.beforeFirst();
		} catch(SQLException e) {
			return size;
		}
		return size;
	}


}