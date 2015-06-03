package com.SERV.interfaceAbility;

import com.SERV.view.entity.Group;

/**
 * Created by prizrak on 29.05.2015.
 */
public interface InterfaceGroup {
    public boolean setGroup(Group g);
    public boolean updGroup(Group g);

    public Group getGroup(Integer val);
}
