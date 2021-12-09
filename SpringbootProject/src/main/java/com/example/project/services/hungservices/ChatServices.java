/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services.hungservices;

import com.example.project.entities.Chatroom;
import com.example.project.repositories.hungrepo.ChatRepository;
import java.util.List;
import org.springframework.stereotype.Service;

/**
 *
 * @author Admin
 */
@Service
public class ChatServices implements ChatInterface{
    
    //init repo
    private ChatRepository repo;
    List<Chatroom> listAll;
    
    //init constructor
    public ChatServices(ChatRepository repo,List<Chatroom> listAll)
    {
        this.repo = repo;
        this.listAll = listAll;
    }
    @Override
    public List<Chatroom> findAllChatRoom(int id) {
        return repo.findAllChatRoom(id);
    }

    @Override
    public Chatroom UpdateChatRoom(Chatroom c) {
        Chatroom result = new Chatroom();
        try {
            result = repo.save(c);
        } catch (Exception e) {
            System.out.println("Error :"+ e.getMessage());
        }
        return result;
    }
    
}
