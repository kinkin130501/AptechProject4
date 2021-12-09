/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services.hungservices;

import com.example.project.entities.Notification;
import java.util.List;

/**
 *
 * @author Admin
 */
public interface NotificationInterface {
    List<Notification> findAll();
    Notification UpdateNoti(Notification z);
    boolean DeleteNoti (Notification z);
    List<Notification> findAllNotiByUserid (int id);
}
