/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.repositories.hungrepo;

import com.example.project.entities.Chatroom;
import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

/**
 *
 * @author Admin
 */
public interface ChatRepository extends JpaRepository<Chatroom, Integer> {
    //find chatroom
    @Query(value ="SELECT u FROM Chatroom u WHERE u.chatusergroup = :chatusergroup")
    List<Chatroom> findAllChatRoom(@Param("chatusergroup") int id);
}
