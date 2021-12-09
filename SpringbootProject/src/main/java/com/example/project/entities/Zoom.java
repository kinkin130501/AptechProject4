/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.entities;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Lob;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Admin
 */
@Entity
@Table(name = "Zoom")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Zoom.findAll", query = "SELECT z FROM Zoom z"),
    @NamedQuery(name = "Zoom.findByZoomid", query = "SELECT z FROM Zoom z WHERE z.zoomid = :zoomid"),
    @NamedQuery(name = "Zoom.findByZoomtitle", query = "SELECT z FROM Zoom z WHERE z.zoomtitle = :zoomtitle"),
    @NamedQuery(name = "Zoom.findByZoomstarturl", query = "SELECT z FROM Zoom z WHERE z.zoomstarturl = :zoomstarturl"),
    @NamedQuery(name = "Zoom.findByZoomhost", query = "SELECT z FROM Zoom z WHERE z.zoomhost = :zoomhost"),
    @NamedQuery(name = "Zoom.findByZoomjoinurl", query = "SELECT z FROM Zoom z WHERE z.zoomjoinurl = :zoomjoinurl"),
    @NamedQuery(name = "Zoom.findByZoomagenda", query = "SELECT z FROM Zoom z WHERE z.zoomagenda = :zoomagenda"),
    @NamedQuery(name = "Zoom.findByZoomstarttime", query = "SELECT z FROM Zoom z WHERE z.zoomstarttime = :zoomstarttime"),
    @NamedQuery(name = "Zoom.findByZoompass", query = "SELECT z FROM Zoom z WHERE z.zoompass = :zoompass"),
    @NamedQuery(name = "Zoom.findByZoomteam", query = "SELECT z FROM Zoom z WHERE z.zoomteam = :zoomteam"),
    @NamedQuery(name = "Zoom.findByZoommember", query = "SELECT z FROM Zoom z WHERE z.zoommember = :zoommember"),
    @NamedQuery(name = "Zoom.findByZoomcreateat", query = "SELECT z FROM Zoom z WHERE z.zoomcreateat = :zoomcreateat"),
    @NamedQuery(name = "Zoom.findByZoomupdateat", query = "SELECT z FROM Zoom z WHERE z.zoomupdateat = :zoomupdateat")})
public class Zoom implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "zoomid")
    private Integer zoomid;
    @Size(max = 255)
    @Column(name = "zoomtitle")
    private String zoomtitle;
    @Lob
    @Size(max = 2147483647)
    @Column(name = "zoomcode")
    private String zoomcode;
    @Size(max = 2147483647)
    @Column(name = "zoomstarturl")
    private String zoomstarturl;
    @Column(name = "zoomhost")
    private Integer zoomhost;
    @Size(max = 2147483647)
    @Column(name = "zoomjoinurl")
    private String zoomjoinurl;
    @Size(max = 255)
    @Column(name = "zoomagenda")
    private String zoomagenda;
    @Size(max = 255)
    @Column(name = "zoomstarttime")
    private String zoomstarttime;
    @Size(max = 255)
    @Column(name = "zoompass")
    private String zoompass;
    @Column(name = "zoomteam")
    private Integer zoomteam;
    @Column(name = "zoommember")
    private Integer zoommember;
    @Size(max = 50)
    @Column(name = "zoomcreateat")
    private String zoomcreateat;
    @Size(max = 50)
    @Column(name = "zoomupdateat")
    private String zoomupdateat;

    public Zoom() {
    }

    public Zoom(Integer zoomid) {
        this.zoomid = zoomid;
    }

    public Integer getZoomid() {
        return zoomid;
    }

    public void setZoomid(Integer zoomid) {
        this.zoomid = zoomid;
    }

    public String getZoomtitle() {
        return zoomtitle;
    }

    public void setZoomtitle(String zoomtitle) {
        this.zoomtitle = zoomtitle;
    }

    public String getZoomcode() {
        return zoomcode;
    }

    public void setZoomcode(String zoomcode) {
        this.zoomcode = zoomcode;
    }

    public String getZoomstarturl() {
        return zoomstarturl;
    }

    public void setZoomstarturl(String zoomstarturl) {
        this.zoomstarturl = zoomstarturl;
    }

    public Integer getZoomhost() {
        return zoomhost;
    }

    public void setZoomhost(Integer zoomhost) {
        this.zoomhost = zoomhost;
    }

    public String getZoomjoinurl() {
        return zoomjoinurl;
    }

    public void setZoomjoinurl(String zoomjoinurl) {
        this.zoomjoinurl = zoomjoinurl;
    }

    public String getZoomagenda() {
        return zoomagenda;
    }

    public void setZoomagenda(String zoomagenda) {
        this.zoomagenda = zoomagenda;
    }

    public String getZoomstarttime() {
        return zoomstarttime;
    }

    public void setZoomstarttime(String zoomstarttime) {
        this.zoomstarttime = zoomstarttime;
    }

    public String getZoompass() {
        return zoompass;
    }

    public void setZoompass(String zoompass) {
        this.zoompass = zoompass;
    }

    public Integer getZoomteam() {
        return zoomteam;
    }

    public void setZoomteam(Integer zoomteam) {
        this.zoomteam = zoomteam;
    }

    public Integer getZoommember() {
        return zoommember;
    }

    public void setZoommember(Integer zoommember) {
        this.zoommember = zoommember;
    }

    public String getZoomcreateat() {
        return zoomcreateat;
    }

    public void setZoomcreateat(String zoomcreateat) {
        this.zoomcreateat = zoomcreateat;
    }

    public String getZoomupdateat() {
        return zoomupdateat;
    }

    public void setZoomupdateat(String zoomupdateat) {
        this.zoomupdateat = zoomupdateat;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (zoomid != null ? zoomid.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Zoom)) {
            return false;
        }
        Zoom other = (Zoom) object;
        if ((this.zoomid == null && other.zoomid != null) || (this.zoomid != null && !this.zoomid.equals(other.zoomid))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.example.project.entities.Zoom[ zoomid=" + zoomid + " ]";
    }
    
}
