/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services.hungservices;

import com.example.project.entities.Chatroom;
import com.example.project.entities.Groupuser;
import com.example.project.entities.Privatemessage;
import com.example.project.entities.User;
import java.util.List;

/**
 *
 * @author Admin
 */
public interface MessageInterface {
    List<Privatemessage> findAllMessageById();
    Privatemessage findOneMessage(int id);
    Privatemessage UpdateMessage(Privatemessage m);
    boolean DeleteMessage (int id);
    List<Privatemessage> findMessageByIdSent(int id);
    List<Privatemessage> findMessageByIdInbox(int id);
    List<User> findAllUser();
    List<Groupuser> findAllGroupUser(int id);
    List<Groupuser> findAllMyGroupUser(int id);
}
