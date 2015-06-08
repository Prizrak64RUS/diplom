package com.SERV.view;


import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.InterfaceUser;
import com.SERV.interfaceAbility.UrlController;
import com.SERV.view.entity.User;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import java.util.ArrayList;

/**
 * Created by Prizrak on 08.07.2014.
 */
@Controller
@RequestMapping(UrlController.userObj)
public class  ControllerUser implements InterfaceUser{
/*
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
        return DataProcessing.getProcessingUser().authentication(new User(login,password));
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json")
    @ResponseBody
    public User authentication(@RequestBody final User usr){
        return DataProcessing.getProcessingUser().authentication(usr);
    }
*/
    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.userInsert)
    @ResponseBody
    public void setUsers(@RequestBody final ArrayList<User> user){
        ControllerConnections.getUserController().setUsers(user);
    }


    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.userUpdate)
    @ResponseBody
    public void updateUsers(@RequestBody final ArrayList<User> user){
        ControllerConnections.getUserController().updateUsers(user);
    }


    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.userDelete)
    @ResponseBody
    public void deleteUsers(@RequestBody final ArrayList<User> user){
        ControllerConnections.getUserController().deleteUsers(user);
    }


    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.userAuth)
    @ResponseBody
    public User isAutch(@RequestBody final User user){
        return  ControllerConnections.getUserController().isAutch(user);
    }


    @RequestMapping(method = RequestMethod.POST, value=UrlController.userAll)
    @ResponseBody
    public ArrayList<User> getUsers(){
        return ControllerConnections.getUserController().getUsers();
}


    @RequestMapping(method = RequestMethod.POST, value = UrlController.usersFromEvent)
    @ResponseBody
    public ArrayList<User> getUsers(@PathVariable int idEvent){System.out.println(idEvent); return ControllerConnections.getUserController().getUsers(idEvent);}

}
