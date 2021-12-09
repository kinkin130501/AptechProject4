/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services.hungservices;

import com.example.project.entities.Chatroom;
import java.util.List;

/**
 *
 * @author Admin
 */
public interface ChatInterface {
    List<Chatroom> findAllChatRoom(int id);
    Chatroom UpdateChatRoom(Chatroom c);
}
