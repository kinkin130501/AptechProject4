/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.repositories;

import com.example.project.entities.Projects;
import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

/**
 *
 * @author vuchu
 */
public interface ProjectRepository extends JpaRepository<Projects, Integer> {
//    @Query(value = "select p from Projects p where lower(p.projectname)"
//            + " like lower(concat('%', :projectname, '%')) ")
//    List<Projects> searchByName(@Param("projectname") String projectname);
}
