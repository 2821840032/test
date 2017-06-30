package com.bean;

public class ASIUrl {
    private Integer urlid;

    private String url;

    private String suri;

    public Integer getUrlid() {
        return urlid;
    }

    public void setUrlid(Integer urlid) {
        this.urlid = urlid;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url == null ? null : url.trim();
    }

    public String getSuri() {
        return suri;
    }

    public void setSuri(String suri) {
        this.suri = suri == null ? null : suri.trim();
    }
}