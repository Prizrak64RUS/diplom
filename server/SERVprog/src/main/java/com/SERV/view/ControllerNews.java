package com.SERV.view;

import com.SERV.interfaceAbility.InterfaceNews;
import com.SERV.interfaceAbility.UrlController;
import com.SERV.model.DataProcessing;
import com.SERV.view.entity.News;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;

/**
 * Created by prizrak on 16.03.2015.
 */
@Controller
@RequestMapping(UrlController.newsObj)
public class ControllerNews implements InterfaceNews{

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.newsInsert)
    @ResponseBody
    public void setNews(@RequestBody final News news){DataProcessing.getProcessingNews().setNews(news);}


    @RequestMapping(method = RequestMethod.POST, value = UrlController.newsGetOf)
    @ResponseBody
    public ArrayList<News> getNewsOf(@PathVariable int id){return DataProcessing.getProcessingNews().getNewsOf(id);}

    @RequestMapping(method = RequestMethod.POST, value=UrlController.newsEndSeven)
    @ResponseBody
    public ArrayList<News> getEndSevenNews(){return DataProcessing.getProcessingNews().getEndSevenNews();}
}