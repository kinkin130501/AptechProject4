/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.repositories.hungrepo;

import com.example.project.entities.Notification;
import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

/**
 *
 * @author Admin
 */
public interface NotificationRepository extends JpaRepository<Notification, Integer> {
    @Query(value ="SELECT p FROM Notification p WHERE p.notiuserid = :notiuserid")
    List<Notification> findAllNotiByUserid(@Param("notiuserid") int id);
}
