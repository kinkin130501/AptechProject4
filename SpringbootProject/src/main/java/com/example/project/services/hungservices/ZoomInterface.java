/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services.hungservices;

import com.example.project.entities.Zoom;
import java.util.List;

/**
 *
 * @author Admin
 */
public interface ZoomInterface {
    List<Zoom> findAllTeamZoom();
    List<Zoom> findAllZoomById(int id);
    List<Zoom> findAllZoomByIdOther(int id);
    Zoom findOneZoom(int id);
    Zoom UpdateZoom(Zoom z);
    boolean DeleteZoom (Zoom z);
//    Zoom CreateZoom(Zoom z);
}
