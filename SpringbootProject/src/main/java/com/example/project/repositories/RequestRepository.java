/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.repositories;

import com.example.project.entities.Request;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 *
 * @author vuman
 */
public interface RequestRepository extends JpaRepository<Request, Integer> {
    
}
