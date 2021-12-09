/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.repositories;

import com.example.project.entities.Affairs;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 *
 * @author vuchu
 */
public interface AffairRepository extends JpaRepository<Affairs, Integer> {
//    @Query(value = "select f from Affairs f where lower(f.affairname)"
//            + " like lower(concat('%', :affairname, '%')) ")
//    List<Affairs> searchByName(@Param("affairname") String affairname);
}
