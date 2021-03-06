package com.dao;

import com.bean.ASIUrl;
import com.bean.ASIUrlExample;
import java.util.List;
import org.apache.ibatis.annotations.Param;

public interface ASIUrlMapper {
	
	List<ASIUrl> geturls();
	
    int countByExample(ASIUrlExample example);

    int deleteByExample(ASIUrlExample example);

    int deleteByPrimaryKey(Integer urlid);

    int insert(ASIUrl record);

    int insertSelective(ASIUrl record);

    List<ASIUrl> selectByExample(ASIUrlExample example);

    ASIUrl selectByPrimaryKey(Integer urlid);

    int updateByExampleSelective(@Param("record") ASIUrl record, @Param("example") ASIUrlExample example);

    int updateByExample(@Param("record") ASIUrl record, @Param("example") ASIUrlExample example);

    int updateByPrimaryKeySelective(ASIUrl record);

    int updateByPrimaryKey(ASIUrl record);
}