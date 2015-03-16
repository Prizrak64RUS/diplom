package com.SERV.interfaceAbility;

import com.SERV.view.entity.Message;

import java.util.ArrayList;

/**
 * Created by prizrak on 20.01.2015.
 */
public interface InterfaceChat {
    public void setChatMessage(Message ms);
    public ArrayList<Message> getChatOf(int id);
    public ArrayList<Message> getEndSevenMessage();
}
