/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services.hungservices;

import com.example.project.entities.Notification;
import com.example.project.repositories.hungrepo.NotificationRepository;
import java.util.List;
import org.springframework.stereotype.Service;

/**
 *
 * @author Admin
 */
@Service
public class NotificationServices implements NotificationInterface{
    //init repo
    private NotificationRepository repo;
    List<Notification> listAll;
    public NotificationServices(NotificationRepository repo,List<Notification> listAll)
    {
        this.repo = repo;
        this.listAll = listAll;
    }
    @Override
    public List<Notification> findAll() {
        return repo.findAll();
    }

    @Override
    public Notification UpdateNoti(Notification z) {
        Notification result = new Notification();
        try {
            result = repo.save(z);
        } catch (Exception e) {
            System.out.println("Error :"+ e.getMessage());
        }
        return result;
    }

    @Override
    public boolean DeleteNoti(Notification z) {
        boolean flag = true;
        try {
            repo.deleteById(z.getNotiid());
        } catch (Exception e) {
            System.out.println("Error :"+ e.getMessage());
            flag = false;
        }
        return flag;
    }

    @Override
    public List<Notification> findAllNotiByUserid (int id) {
        return repo.findAllNotiByUserid(id);
    }
    
}
