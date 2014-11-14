/**
 * 
 */
package com.SOPG.dataBase;


/**
 * @author vladimir
 *
 */
public enum TypeToVariable {

	DB_LOGIN("db_login","root"),
	DB_PASSWORD("db_password","123456"),
	DB_IP("db_ip","localhost"),
	DB_PORT("db_port","3306"),
	DB_NAME("db_name","sopg_db"),
	DB_URL("db_url");
	
	/**
	 * 
	 */
	private String name;
	private String value;
	
	private TypeToVariable(String name) {
		this.name=name;
	}
	private TypeToVariable(String name , String value) {
		this.name=name;
		this.value=value;
	}
	public String getName(){
		return name;
	}
	public String getValue(){
		return value;
	}
	public void setValue(String value){
	this.value=value;	
	}
	public String toString(){
		return name;
	}
}
