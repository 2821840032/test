package com.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.bean.ASIUData;
import com.bean.ASIUrl;
import com.dao.ASIUDataMapper;
import com.dao.ASIUrlMapper;
@Service
public class ASIServiceImpl implements IASIService {

	@Autowired
	private ASIUrlMapper am;
	@Autowired
	private ASIUDataMapper adm;
	
	@Override
	public List<List<String>> getData() {
		// TODO Auto-generated method stub
		List<ASIUrl> urls = am.geturls();
		List<List<String>> datas = new ArrayList<List<String>>();
		for (int i = 0; i < urls.size(); i++) {
			List<String> temps = new ArrayList<String>();
			List<ASIUData> ud = adm.getudatas(urls.get(i).getUrlid());
			temps.add(urls.get(i).getUrl());
			for (int j = 0; j < ud.size(); j++) {
				temps.add(ud.get(j).getUrldata());
			}
			datas.add(temps);
			temps=null;
		}
		for (int i = 0; i < datas.size(); i++) {
			List<String> temp = datas.get(i);
			System.out.println("==================");
			for (int s = 0; s < temp.size(); s++) {
				System.out.println(temp.get(s));
			}
			temp=null;
		}
		return datas;
	}

}
