using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMP.PublicClass
{
    class StaffTitleUtil
    {
        //私有化构造函数
        private StaffTitleUtil() { }

        //相应的Title
        //姓名Title
        private static string titleNameStr = "姓名";
        private static string titleNameValue = "Name";
        private static int titleNameIndex = 3;

        //部门Title
        private static string titleDpmStr = "部门";
        private static string titleDpmValue = "Dpm";
        private static int titleDpmIndex = 5;

        //证件类型Title
        private static string titlePapStr = "证件类型";
        private static string titlePapValue = "Pap";
        private static int titlePapIndex = 7;

        //证件号码Title
        private static string titlePapNumStr = "证件号码";
        private static string titlePapNumValue = "PapNum";
        private static int titlePapNumIndex = 11;

        //头像Title
        private static string titlePhotoStr = "头像";
        private static string titlePhotoValue = "Photo";
        private static int titlePhotoIndex = 13;

        //入职日期Title
        private static string titleDateInStr = "入职日期";
        private static string titleDateInValue = "DateIn";
        private static int titleDateInIndex = 17;

        //工号Title
        private static string titleStaffNumStr = "工号";
        private static string titleStaffNumValue = "StaffNum";
        private static int titleStaffNumIndex = 19;

        //性别Title
        private static string titleSexStr = "性别";
        private static string titleSexValue = "Sex";
        private static int titleSexIndex = 23;

        //名族Title
        private static string titleNationStr = "名族";
        private static string titleNationValue = "Nation";
        private static int titleNationIndex = 29;

        //出生地点Title
        private static string titleBirthPlaceStr = "出生地点";
        private static string titleBirthPlaceValue = "BirthPlace";
        private static int titleBirthPlaceIndex = 31;

        //户籍Title
        private static string titleRegPlaceStr = "户籍";
        private static string titleRegPlaceValue = "RegPlace";
        private static int titleRegPlaceIndex = 37;

        //教育背景Title
        private static string titleEduBkStr = "教育背景";
        private static string titleEduBkValue = "EduBk";
        private static int titleEduBkIndex = 41;

        //工作日期Title
        private static string titleDateWorkStr = "工作日期";
        private static string titleDateWorkValue = "DateWork";
        private static int titleDateWorkIndex = 43;

        //UrgencyTitle
        private static string titleUrgencyNumStr = "紧急号码";
        private static string titleUrgencyNumValue = "UrgencyNum";
        private static int titleUrgencyNumIndex = 47;

        //教育经历Title
        private static string titleEduExpStr = "教育经验";
        private static string titleEduExpValue = "EduExp";
        private static int titleEduExpIndex = 53;

        //培训经验Title
        private static string titleTrainExpStr = "培训经验";
        private static string titleTrainExpValue = "TrainExp";
        private static int titleTrainExpIndex = 59;

        //工作经验Title
        private static string titleWorkExpStr = "工作经验";
        private static string titleWorkExpValue = "WorkExp";
        private static int titleWorkExpIndex = 61;

        //家庭号码Title
        private static string titleFamilyNumStr = "家庭号码";
        private static string titleFamilyNumValue = "FamilyNum";
        private static int titleFamilyNumIndex = 67;

        //得到想要的Title
        public static string getTitleByNum(int i)
        {
            string str = "";
            bool flag = false;

            //添加各项
            if (i % titleNameIndex==0)
            {
                if (flag) str += " , ";
                str += titleNameValue;
                str += " AS ";
                str += titleNameStr;
                flag = true;
            }
            

            if (i % titleDpmIndex == 0)
            {
                if (flag) str += " , ";
                str += titleDpmValue;
                str += " AS ";
                str += titleDpmStr;
                flag = true;
            }
            


            if (i % titlePapIndex == 0)
            {
                if (flag) str += " , ";
                str += titlePapValue;
                str += " AS ";
                str += titlePapStr;
                flag = true;
            }
            

            if (i % titlePapNumIndex == 0)
            {
                if (flag) str += " , ";
                str += titlePapNumValue;
                str += " AS ";
                str += titlePapNumStr;
                flag = true;
            }

            if (i % titlePhotoIndex == 0)
            {
                if (flag) str += " , ";
                str += titlePhotoValue;
                str += " AS ";
                str += titlePhotoStr;
                flag = true;
            }
            

            if (i % titleDateInIndex == 0)
            {
                if (flag) str += " , ";
                str += titleDateInValue;
                str += " AS ";
                str += titleDateInStr;
                flag = true;
            }
           
            if (i % titleStaffNumIndex == 0)
            {
                if (flag) str += " , ";
                str += titleStaffNumValue;
                str += " AS ";
                str += titleStaffNumStr;
                flag = true;
            }
            
            if (i % titleSexIndex == 0)
            {
                if (flag) str += " , ";
                str += titleSexValue;
                str += " AS ";
                str += titleSexStr;
                flag = true;
            }

            if (i % titleNationIndex == 0)
            {
                if (flag) str += " , ";
                str += titleNationValue;
                str += " AS ";
                str += titleNationStr;
                flag = true;
            }
            
            if (i % titleBirthPlaceIndex == 0)
            {
                if (flag) str += " , ";
                str += titleBirthPlaceValue;
                str += " AS ";
                str += titleBirthPlaceStr;
                flag = true;
            }
            
            if (i % titleRegPlaceIndex == 0)
            {
                if (flag) str += " , ";
                str += titleRegPlaceValue;
                str += " AS ";
                str += titleRegPlaceStr;
                flag = true;
            }
            
            if (i % titleEduBkIndex == 0)
            {
                if (flag) str += " , ";
                str += titleEduBkValue;
                str += " AS ";
                str += titleEduBkStr;
                flag = true;
            }
            
            if (i % titleDateWorkIndex == 0)
            {
                if (flag) str += " , ";
                str += titleDateWorkValue;
                str += " AS ";
                str += titleDateWorkStr;
                flag = true;
            }
            
            if (i % titleUrgencyNumIndex == 0)
            {
                if (flag) str += " , ";
                str += titleUrgencyNumValue;
                str += " AS ";
                str += titleUrgencyNumStr;
                flag = true;
            }
            
            if (i % titleEduExpIndex == 0)
            {
                if (flag) str += " , ";
                str += titleEduExpValue;
                str += " AS ";
                str += titleEduExpStr;
                flag = true;
            }
            
            if (i % titleTrainExpIndex == 0)
            {
                if (flag) str += " , ";
                str += titleTrainExpValue;
                str += " AS ";
                str += titleTrainExpStr;
                flag = true;
            }
            
            if (i % titleWorkExpIndex == 0)
            {
                if (flag) str += " , ";
                str += titleWorkExpValue;
                str += " AS ";
                str += titleWorkExpStr;
                flag = true;
            }
            

            if (i % titleFamilyNumIndex == 0)
            {
                if (flag) str += " , ";
                str += titleFamilyNumValue;
                str += " AS ";
                str += titleFamilyNumStr;
                flag = true;
            }
            return str;
        }
    }
}
