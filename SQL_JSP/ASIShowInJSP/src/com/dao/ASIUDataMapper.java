package com.dao;

import com.bean.ASIUData;
import com.bean.ASIUDataExample;
import java.util.List;
import org.apache.ibatis.annotations.Param;

public interface ASIUDataMapper {
	
	List<ASIUData> getudatas(Integer urlid);
	
    int countByExample(ASIUDataExample example);

    int deleteByExample(ASIUDataExample example);

    int deleteByPrimaryKey(Integer dataid);

    int insert(ASIUData record);

    int insertSelective(ASIUData record);

    List<ASIUData> selectByExample(ASIUDataExample example);

    ASIUData selectByPrimaryKey(Integer dataid);

    int updateByExampleSelective(@Param("record") ASIUData record, @Param("example") ASIUDataExample example);

    int updateByExample(@Param("record") ASIUData record, @Param("example") ASIUDataExample example);

    int updateByPrimaryKeySelective(ASIUData record);

    int updateByPrimaryKey(ASIUData record);
}