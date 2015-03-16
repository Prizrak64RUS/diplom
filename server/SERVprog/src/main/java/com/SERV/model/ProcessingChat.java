package com.SERV.model;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.InterfaceChat;
import com.SERV.view.entity.Message;

import java.util.ArrayList;

/**
 * Created by prizrak on 16.03.2015.
 */
public class ProcessingChat implements InterfaceChat {
    public void setChatMessage(Message ms){
        ControllerConnections.getChatController().setChatMessage(ms);}

    public ArrayList<Message> getChatOf(int id){return ControllerConnections.getChatController().getChatOf(id);}

    public ArrayList<Message> getEndSevenMessage(){return ControllerConnections.getChatController().getEndSevenMessage();}
}
