package com.SERV.interfaceAbility;

/**
 * Created by prizrak on 16.03.2015.
 */
public interface UrlController {
    String userObj="/user/";
    String userInsert="insert";
    String userUpdate="update";
    String userDelete="delete";
    String userAll="allUser";
    String usersFromEvent="allUser/{idEvent}";
    String userAuth = "auth";

    String mapsObj="/maps/";
    String mapFromEventAll="allMap/in/";
    String mapFromId_ = "allMap/id/{id}";
    String mapActivEventAll="allMap/selected/";
    String mapAll="allMap";
    String mapsInsert="insert";
    String mapsDelete="delete";
    String mapsUpdate="update";
    String mapsSendOut="sendOut/{id}";
    String mapsSendIn="sendIn/{id}";
    String mapSize="mapSize/{id}";

    String eventObj="/event/";
    String eventGetActiv="getActiv";
    String eventInsert="insert";
    String eventUpd="upd";
    String eventAll="allEvent";

    String pointObj="/point/";
    String pointFromMap="allPoint";
    String pointUpdate="update";
    String pointsInsert="inserts";
    String pointDelete="delete";

    String pointBusy="busy/busy";
    String pointNotBusy="busy/notbusy";
    String pointBusyUpdate="busy/update";
    String pointBusyDelete="busy/delete";
    String pointBusyInsert="busy/insert";

    String pointGetPoint_="gp/{id}";
    String pointSetPoint="sp";
    String pointDelPoint="dp";


    String pointUpdFree_space="updfreespace";

    String logObj="/log/";
    String logNews="news";
    String logPoint="point";
    String logChat="chat";
    String logGroup="group";

    String logInsert="insert";
  /*
    String logGetTreeLog="treeLogs/{idEvent}";
    String logGetTreeLogByType="treeLogs";*/

    String chatObj="/chat/";
    String chatInsert="insert";
    String chatGetOf="getOf";
    String chatEndSevenMessage="endSevenMessage";

    String newsObj="/news/";
    String newsInsert="insert";
    String newsGetOf="getOf/{id}";
    String newsEndSeven="endSeven";

    String busyObj="/busy/";
    String busyInsert="insert";
    String busyDel="delete";
    String busyIs="is";

    String groupObj="/group/";
    String groupUpdate="update";
    String groupInsert="inserts";
    String groupGet="get";

    String schedulepointObj = "/schedulepoint/";
    String schedulepointGetOne = "getone";
    String schedulepointIns = "insert";
    String schedulepointDel = "delete";
    String schedulepointUpd = "update";
    String schedulepointGet = "get";
    String schedulepointGetFrom = "getfrom";

    String masterclassObj = "/masterclass/";
    String masterclassGetOne = "getone";
    String masterclassIns = "insert";
    String masterclassDel = "delete";
    String masterclassUpd = "update";
    String masterclassGet = "get";
    String masterclassGetFrom = "getfrom";



}
