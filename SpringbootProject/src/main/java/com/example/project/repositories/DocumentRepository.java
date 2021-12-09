/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.repositories;

import com.example.project.entities.Documents;
import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

/**
 *
 * @author vuchu
 */
public interface DocumentRepository extends JpaRepository<Documents, Integer> {
//    @Query(value = "select d from Documents d where lower(d.title) "
//            + "like lower(concat('%', :search, '%')) " 
//            + "or lower(d.authorname) like lower(concat('%', :search, '%'))")
//    List<Documents> searchDocument(@Param("search") String search);
}
