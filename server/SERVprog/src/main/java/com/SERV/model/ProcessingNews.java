package com.SERV.model;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.InterfaceNews;
import com.SERV.view.entity.News;

import java.util.ArrayList;

/**
 * Created by prizrak on 16.03.2015.
 */
public class ProcessingNews implements InterfaceNews {
    public void setNews(News news){
        ControllerConnections.getNewsController().setNews(news);}

    public ArrayList<News> getNewsOf(int id){return ControllerConnections.getNewsController().getNewsOf(id);}

    public ArrayList<News> getEndSevenNews(){return ControllerConnections.getNewsController().getEndSevenNews();}
}
