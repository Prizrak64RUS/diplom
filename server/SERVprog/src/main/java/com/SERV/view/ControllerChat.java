package com.SERV.view;

import com.SERV.interfaceAbility.InterfaceChat;
import com.SERV.interfaceAbility.UrlController;
import com.SERV.model.DataProcessing;
import com.SERV.view.entity.Message;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import java.util.ArrayList;
/**
 * Created by prizrak on 16.03.2015.
 */
@Controller
@RequestMapping(UrlController.chatObj)
public class ControllerChat implements InterfaceChat{

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.chatInsert)
    @ResponseBody
    public void setChatMessage(@RequestBody final Message ms){DataProcessing.getProcessingChat().setChatMessage(ms);}


    @RequestMapping(method = RequestMethod.POST, value = UrlController.chatGetOf)
    @ResponseBody
    public ArrayList<Message> getChatOf(@PathVariable int id){return DataProcessing.getProcessingChat().getChatOf(id);}

    @RequestMapping(method = RequestMethod.POST, value=UrlController.chatEndSevenMessage)
    @ResponseBody
    public ArrayList<Message> getEndSevenMessage(){return DataProcessing.getProcessingChat().getEndSevenMessage();}
}
