/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.repositories.hungrepo;

import org.springframework.data.repository.CrudRepository;
import com.example.project.entities.Zoom;
import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
/**
 *
 * @author Admin
 */
public interface ZoomRepository extends JpaRepository<Zoom, Integer> {
    @Query(value ="SELECT z FROM Zoom z WHERE z.zoomid = :zoomid")
    Zoom findZoomById(@Param("zoomid") int id);
    @Query(value ="SELECT z FROM Zoom z WHERE z.zoomhost = :zoomhost")
    List<Zoom> findAllZoomById(@Param("zoomhost") int id);
    @Query(value ="SELECT z FROM Zoom z WHERE z.zoommember = :zoommember")
    List<Zoom> findAllZoomByIdOther(@Param("zoommember") int id);
}
