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
import com.example.project.repositories.hungrepo.MessageRepository;
import java.util.List;
import org.springframework.stereotype.Service;

/**
 *
 * @author Admin
 */
@Service
public class MessageServices implements MessageInterface{
    //init repo
    private MessageRepository repo;
    List<Privatemessage> listAll;
    
    //init constructor
    public MessageServices(MessageRepository repo,List<Privatemessage> listAll)
    {
        this.repo = repo;
        this.listAll = listAll;
    }
    @Override
    public List<Privatemessage> findAllMessageById() {
        return repo.findAll();
    }

    @Override
    public Privatemessage findOneMessage(int id) {
        return repo.findMessageById(id);
    }

    @Override
    public Privatemessage UpdateMessage(Privatemessage m) {
         Privatemessage result = new Privatemessage();
        try {
            result = repo.save(m);
        } catch (Exception e) {
            System.out.println("Error :"+ e.getMessage());
        }
        return result;
    }

    @Override
    public boolean DeleteMessage(int id) {
        boolean flag = true;
        try {
            repo.deleteById(id);
        } catch (Exception e) {
            System.out.println("Error :"+ e.getMessage());
            flag = false;
        }
        return flag;
    }

    @Override
    public List<Privatemessage> findMessageByIdSent(int id) {
        return repo.findAllMessageByIdSend(id);
    }

    @Override
    public List<Privatemessage> findMessageByIdInbox(int id) {
        return repo.findAllMessageByIdInbox(id);
    }

    @Override
    public List<User> findAllUser() {
        return repo.findAllUser();
    }
    @Override
    public List<Groupuser> findAllGroupUser(int id) {
        return repo.findAllGroupUser(id);
    }
    @Override
    public List<Groupuser> findAllMyGroupUser(int id) {
        return repo.findAllMyGroupUser(id);
    }
}
