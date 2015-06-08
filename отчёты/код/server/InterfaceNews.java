package com.SERV.interfaceAbility;

import com.SERV.view.entity.News;

import java.util.ArrayList;

/**
 * Created by prizrak on 20.01.2015.
 */
public interface InterfaceNews {
    public void setNews(News news);
    public ArrayList<News> getNewsOf(int id);
    public ArrayList<News> getEndSevenNews();
}
