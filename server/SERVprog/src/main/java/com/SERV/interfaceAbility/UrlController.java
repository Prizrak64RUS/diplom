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
    String mapFromEventAll="allMap/{idEvent}";
    String mapsInsert="insert";
    String mapsDelete="delete/{id}";
    String mapsSendOut="sendOut/{id}";

    String eventObj="/event/";
    String eventGetActiv="getActiv";
    String eventInsert="insert";
    String eventAll="allEvent";

    String pointObj="/point/";
    String pointFromMap="allPoint/{idMap}";
    String pointUpdate="update";
    String pointsInsert="inserts";
    String pointDelete="delete";

    String logObj="/log/";
    String logInsert="insert";
    String logGetTreeLog="treeLogs/{idEvent}";
    String logGetTreeLogByType="treeLogs";

    String chatObj="/chat/";
    String chatInsert="insert";
    String chatGetOf="getOf/{id}";
    String chatEndSevenMessage="endSevenMessage";

    String newsObj="/news/";
    String newsInsert="insert";
    String newsGetOf="getOf/{id}";
    String newsEndSeven="endSeven";
}
