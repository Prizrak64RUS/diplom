package com.SERV.view;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.model.DataProcessing;
import com.SERV.view.entity.User;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

/**
 * Created by prizrak on 25.11.2014.
 */
@Controller
@RequestMapping("/test")
public class TestController {
    @RequestMapping(method = RequestMethod.POST)
    @ResponseBody
    public boolean test() {
        return true;
    }
}
