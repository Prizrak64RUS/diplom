package com.SERV.view;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.model.DataProcessing;
import com.SERV.view.entity.User;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;

/**
 * Created by Prizrak on 08.07.2014.
 */
@Controller
@RequestMapping("/user/")
public class UserController {

    @RequestMapping(method = RequestMethod.GET,params ={"id"})
         @ResponseBody
         public User getUser(@RequestParam("id") int id) {
        return DataProcessing.getProcessingUser().getUser(id);
    }

    @RequestMapping(method = RequestMethod.GET,params ={"role"})
    @ResponseBody
    public HashMap<String,User> getUser(@RequestParam("role") String role) {
        return DataProcessing.getProcessingUser().getUserRole(role);
    }

    @RequestMapping( method = RequestMethod.GET, params ={"login", "password"})
    @ResponseBody
    public User isUser(@RequestParam("login") String login,@RequestParam("password") String password) {
        DataProcessing dp = new DataProcessing();
        return DataProcessing.getProcessingUser().authentication(new User(login,password));
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json")
    @ResponseBody
    public User authentication(@RequestBody final User usr){
        return DataProcessing.getProcessingUser().authentication(usr);
    }
}
