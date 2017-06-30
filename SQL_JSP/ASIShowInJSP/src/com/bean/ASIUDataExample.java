package com.bean;

import java.util.ArrayList;
import java.util.List;

public class ASIUDataExample {
    protected String orderByClause;

    protected boolean distinct;

    protected List<Criteria> oredCriteria;

    public ASIUDataExample() {
        oredCriteria = new ArrayList<Criteria>();
    }

    public void setOrderByClause(String orderByClause) {
        this.orderByClause = orderByClause;
    }

    public String getOrderByClause() {
        return orderByClause;
    }

    public void setDistinct(boolean distinct) {
        this.distinct = distinct;
    }

    public boolean isDistinct() {
        return distinct;
    }

    public List<Criteria> getOredCriteria() {
        return oredCriteria;
    }

    public void or(Criteria criteria) {
        oredCriteria.add(criteria);
    }

    public Criteria or() {
        Criteria criteria = createCriteriaInternal();
        oredCriteria.add(criteria);
        return criteria;
    }

    public Criteria createCriteria() {
        Criteria criteria = createCriteriaInternal();
        if (oredCriteria.size() == 0) {
            oredCriteria.add(criteria);
        }
        return criteria;
    }

    protected Criteria createCriteriaInternal() {
        Criteria criteria = new Criteria();
        return criteria;
    }

    public void clear() {
        oredCriteria.clear();
        orderByClause = null;
        distinct = false;
    }

    protected abstract static class GeneratedCriteria {
        protected List<Criterion> criteria;

        protected GeneratedCriteria() {
            super();
            criteria = new ArrayList<Criterion>();
        }

        public boolean isValid() {
            return criteria.size() > 0;
        }

        public List<Criterion> getAllCriteria() {
            return criteria;
        }

        public List<Criterion> getCriteria() {
            return criteria;
        }

        protected void addCriterion(String condition) {
            if (condition == null) {
                throw new RuntimeException("Value for condition cannot be null");
            }
            criteria.add(new Criterion(condition));
        }

        protected void addCriterion(String condition, Object value, String property) {
            if (value == null) {
                throw new RuntimeException("Value for " + property + " cannot be null");
            }
            criteria.add(new Criterion(condition, value));
        }

        protected void addCriterion(String condition, Object value1, Object value2, String property) {
            if (value1 == null || value2 == null) {
                throw new RuntimeException("Between values for " + property + " cannot be null");
            }
            criteria.add(new Criterion(condition, value1, value2));
        }

        public Criteria andDataidIsNull() {
            addCriterion("dataid is null");
            return (Criteria) this;
        }

        public Criteria andDataidIsNotNull() {
            addCriterion("dataid is not null");
            return (Criteria) this;
        }

        public Criteria andDataidEqualTo(Integer value) {
            addCriterion("dataid =", value, "dataid");
            return (Criteria) this;
        }

        public Criteria andDataidNotEqualTo(Integer value) {
            addCriterion("dataid <>", value, "dataid");
            return (Criteria) this;
        }

        public Criteria andDataidGreaterThan(Integer value) {
            addCriterion("dataid >", value, "dataid");
            return (Criteria) this;
        }

        public Criteria andDataidGreaterThanOrEqualTo(Integer value) {
            addCriterion("dataid >=", value, "dataid");
            return (Criteria) this;
        }

        public Criteria andDataidLessThan(Integer value) {
            addCriterion("dataid <", value, "dataid");
            return (Criteria) this;
        }

        public Criteria andDataidLessThanOrEqualTo(Integer value) {
            addCriterion("dataid <=", value, "dataid");
            return (Criteria) this;
        }

        public Criteria andDataidIn(List<Integer> values) {
            addCriterion("dataid in", values, "dataid");
            return (Criteria) this;
        }

        public Criteria andDataidNotIn(List<Integer> values) {
            addCriterion("dataid not in", values, "dataid");
            return (Criteria) this;
        }

        public Criteria andDataidBetween(Integer value1, Integer value2) {
            addCriterion("dataid between", value1, value2, "dataid");
            return (Criteria) this;
        }

        public Criteria andDataidNotBetween(Integer value1, Integer value2) {
            addCriterion("dataid not between", value1, value2, "dataid");
            return (Criteria) this;
        }

        public Criteria andUrlidIsNull() {
            addCriterion("urlid is null");
            return (Criteria) this;
        }

        public Criteria andUrlidIsNotNull() {
            addCriterion("urlid is not null");
            return (Criteria) this;
        }

        public Criteria andUrlidEqualTo(Integer value) {
            addCriterion("urlid =", value, "urlid");
            return (Criteria) this;
        }

        public Criteria andUrlidNotEqualTo(Integer value) {
            addCriterion("urlid <>", value, "urlid");
            return (Criteria) this;
        }

        public Criteria andUrlidGreaterThan(Integer value) {
            addCriterion("urlid >", value, "urlid");
            return (Criteria) this;
        }

        public Criteria andUrlidGreaterThanOrEqualTo(Integer value) {
            addCriterion("urlid >=", value, "urlid");
            return (Criteria) this;
        }

        public Criteria andUrlidLessThan(Integer value) {
            addCriterion("urlid <", value, "urlid");
            return (Criteria) this;
        }

        public Criteria andUrlidLessThanOrEqualTo(Integer value) {
            addCriterion("urlid <=", value, "urlid");
            return (Criteria) this;
        }

        public Criteria andUrlidIn(List<Integer> values) {
            addCriterion("urlid in", values, "urlid");
            return (Criteria) this;
        }

        public Criteria andUrlidNotIn(List<Integer> values) {
            addCriterion("urlid not in", values, "urlid");
            return (Criteria) this;
        }

        public Criteria andUrlidBetween(Integer value1, Integer value2) {
            addCriterion("urlid between", value1, value2, "urlid");
            return (Criteria) this;
        }

        public Criteria andUrlidNotBetween(Integer value1, Integer value2) {
            addCriterion("urlid not between", value1, value2, "urlid");
            return (Criteria) this;
        }

        public Criteria andUrldataIsNull() {
            addCriterion("urldata is null");
            return (Criteria) this;
        }

        public Criteria andUrldataIsNotNull() {
            addCriterion("urldata is not null");
            return (Criteria) this;
        }

        public Criteria andUrldataEqualTo(String value) {
            addCriterion("urldata =", value, "urldata");
            return (Criteria) this;
        }

        public Criteria andUrldataNotEqualTo(String value) {
            addCriterion("urldata <>", value, "urldata");
            return (Criteria) this;
        }

        public Criteria andUrldataGreaterThan(String value) {
            addCriterion("urldata >", value, "urldata");
            return (Criteria) this;
        }

        public Criteria andUrldataGreaterThanOrEqualTo(String value) {
            addCriterion("urldata >=", value, "urldata");
            return (Criteria) this;
        }

        public Criteria andUrldataLessThan(String value) {
            addCriterion("urldata <", value, "urldata");
            return (Criteria) this;
        }

        public Criteria andUrldataLessThanOrEqualTo(String value) {
            addCriterion("urldata <=", value, "urldata");
            return (Criteria) this;
        }

        public Criteria andUrldataLike(String value) {
            addCriterion("urldata like", value, "urldata");
            return (Criteria) this;
        }

        public Criteria andUrldataNotLike(String value) {
            addCriterion("urldata not like", value, "urldata");
            return (Criteria) this;
        }

        public Criteria andUrldataIn(List<String> values) {
            addCriterion("urldata in", values, "urldata");
            return (Criteria) this;
        }

        public Criteria andUrldataNotIn(List<String> values) {
            addCriterion("urldata not in", values, "urldata");
            return (Criteria) this;
        }

        public Criteria andUrldataBetween(String value1, String value2) {
            addCriterion("urldata between", value1, value2, "urldata");
            return (Criteria) this;
        }

        public Criteria andUrldataNotBetween(String value1, String value2) {
            addCriterion("urldata not between", value1, value2, "urldata");
            return (Criteria) this;
        }
    }

    public static class Criteria extends GeneratedCriteria {

        protected Criteria() {
            super();
        }
    }

    public static class Criterion {
        private String condition;

        private Object value;

        private Object secondValue;

        private boolean noValue;

        private boolean singleValue;

        private boolean betweenValue;

        private boolean listValue;

        private String typeHandler;

        public String getCondition() {
            return condition;
        }

        public Object getValue() {
            return value;
        }

        public Object getSecondValue() {
            return secondValue;
        }

        public boolean isNoValue() {
            return noValue;
        }

        public boolean isSingleValue() {
            return singleValue;
        }

        public boolean isBetweenValue() {
            return betweenValue;
        }

        public boolean isListValue() {
            return listValue;
        }

        public String getTypeHandler() {
            return typeHandler;
        }

        protected Criterion(String condition) {
            super();
            this.condition = condition;
            this.typeHandler = null;
            this.noValue = true;
        }

        protected Criterion(String condition, Object value, String typeHandler) {
            super();
            this.condition = condition;
            this.value = value;
            this.typeHandler = typeHandler;
            if (value instanceof List<?>) {
                this.listValue = true;
            } else {
                this.singleValue = true;
            }
        }

        protected Criterion(String condition, Object value) {
            this(condition, value, null);
        }

        protected Criterion(String condition, Object value, Object secondValue, String typeHandler) {
            super();
            this.condition = condition;
            this.value = value;
            this.secondValue = secondValue;
            this.typeHandler = typeHandler;
            this.betweenValue = true;
        }

        protected Criterion(String condition, Object value, Object secondValue) {
            this(condition, value, secondValue, null);
        }
    }
}