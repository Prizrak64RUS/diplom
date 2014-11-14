package com.SERV.view;

import com.SERV.model.DataProcessing;
import com.SERV.view.essence.User;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;

/**
 * Created by Prizrak on 08.07.2014.
 */
@Controller
public class UserController {

    @RequestMapping(value = "/user/", method = RequestMethod.GET,params ={"id"})
         @ResponseBody
         public User getUser(@RequestParam("id") int id) {
        return DataProcessing.getUser(id);
    }

    @RequestMapping(value = "/user/", method = RequestMethod.GET,params ={"role"})
    @ResponseBody
    public HashMap<String,User> getUser(@RequestParam("role") String role) {
        return DataProcessing.getUserRole(role);
    }

    @RequestMapping(value = "/user/", method = RequestMethod.GET, params ={"login", "password"})
    @ResponseBody
    public HashMap<String,String> isUser(@RequestParam("login") String login,@RequestParam("password") String password) {
        return DataProcessing.isUser(login, password);
    }
}
