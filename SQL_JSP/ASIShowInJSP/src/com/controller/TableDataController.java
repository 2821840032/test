package com.controller;


import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;

import com.service.ASIServiceImpl;


@Controller
public class TableDataController {
	
	@Autowired
	private ASIServiceImpl asisi;
	
	@RequestMapping("/getdata")
	public ModelAndView getdata(){
		ModelAndView mav = new ModelAndView("showdata.jsp");
		List<List<String>> datas = asisi.getData();
//		for (int i = 0; i < datas.size(); i++) {
//			List<String> data = datas.get(i);
//			System.out.println("============");
//			for (int j = 0; j < data.size(); j++) {
//				System.out.println(data);
//			}
//		}
		mav.addObject("asidata",datas);
		return mav;
	}
}
