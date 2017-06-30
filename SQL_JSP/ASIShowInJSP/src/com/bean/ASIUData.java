package com.bean;

public class ASIUData {
    private Integer dataid;

    private Integer urlid;

    private String urldata;

    public Integer getDataid() {
        return dataid;
    }

    public void setDataid(Integer dataid) {
        this.dataid = dataid;
    }

    public Integer getUrlid() {
        return urlid;
    }

    public void setUrlid(Integer urlid) {
        this.urlid = urlid;
    }

    public String getUrldata() {
        return urldata;
    }

    public void setUrldata(String urldata) {
        this.urldata = urldata == null ? null : urldata.trim();
    }
}