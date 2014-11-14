/**
 * 
 */
package com.SOPG.dataBase;

/**
 * @author vladimir
 *
 */

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;

public class ReaderDataToConnectDB{
	
	protected BufferedReader reader;
	private File f; 
	
	protected static HashMap<String, String> data;
	
	protected static String filePath="SOPG.conf";
	
	protected static String url="jdbc:mysql://";
	
	/***
	 * 
	 * @throws java.io.FileNotFoundException
	 */
	public ReaderDataToConnectDB() throws FileNotFoundException {
		f = new File(filePath);
		if (!f.canRead()) {
			throw new FileNotFoundException("Файл " + f.getAbsolutePath() + " не найден!");
		}
	}
	/***
	 * 
	 * @param filePath
	 * @throws java.io.FileNotFoundException
	 */
	public ReaderDataToConnectDB(String filePath) throws FileNotFoundException {
		f = new File(filePath);
		if (!f.canRead()) {
			throw new FileNotFoundException("Файл " + f.getAbsolutePath() + " не найден!");
		}
	}
	
	/***
	 * 
	 */
	public static void reRead(){
		try {
			ReaderDataToConnectDB r = new ReaderDataToConnectDB();
			r.fillingData();
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	/***
	 * 
	 */
	private void fillingData() {
		try {
			Init();
			String line;
			data=new HashMap<String,String>();
			while ((line = reader.readLine()) != null) {
				try{
				if(line == null || line.length() == 0){
					continue;
				}
				String[] arrStr=line.split("[ =]+");
				data.put(arrStr[0],arrStr[1]);
				}
				catch(Exception e){
					
				}
			}
			reader.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	
	/***
	 * 
	 * @param type
	 * @return
	 */
	public static String getData(String type){
		if(data==null){
			try {
				ReaderDataToConnectDB reader = new ReaderDataToConnectDB();
				reader.fillingData();
				reader.IsCorrectData();
			} catch (FileNotFoundException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		String dataStr=data.get(type);
	//	if(dataStr==null) {
	//		WriteOptionError(type);
	//	}
		return dataStr;
	}
	
	/***
	 * 
	 * @return
	 */
	protected boolean IsCorrectData() {
		TypeToVariable[] typeArr = TypeToVariable.values();
		String exeptionData="\n";
		boolean key=true;
		if((typeArr.length-1) != data.size()){
			exeptionData+="The amount of data does not coincide with the original.\n";
			key=false;
		}
		for(int i=0;i<typeArr.length;i++){
			
			if(typeArr[i].getName().equals(TypeToVariable.DB_URL.getName())){
				continue;
			}
			
			if(! IsIncludedValue(typeArr[i].getName())){
				exeptionData+="Data "+typeArr[i].getName()+" does not exist.\n";
				data.put(typeArr[i].getName(), typeArr[i].getValue());
				key=false;
			}
			
			data.put(TypeToVariable.DB_URL.getName(), 
					url+data.get(TypeToVariable.DB_IP.getName()) +
					":"+data.get(TypeToVariable.DB_PORT.getName())  +
					"/"+data.get(TypeToVariable.DB_NAME.getName()));
		}
		
		System.err.println(exeptionData);
		
		return key;
	}
	
	/***
	 * 
	 * @param type
	 * @return
	 */
	private boolean IsIncludedValue (String type) {

		String value = data.get(type);
		if(value==null||value==""){
			return false;
		}
		else{
			return true;
		}
	}
	
	/***
	 * 
	 * @throws java.io.IOException
	 */
	protected void Init() throws IOException {
		reader = new BufferedReader(
				new InputStreamReader(
						new FileInputStream(f)
					)
				);
	}

	protected static void WriteOptionError(String str) {
		System.err.println("Not option in file is "+str);
	}
}