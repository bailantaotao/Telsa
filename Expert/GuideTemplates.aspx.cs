using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_GuideTemplates : System.Web.UI.Page
{
    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    protected void Page_Load(object sender, EventArgs e)
    {
        LbTemplatesContent.Text += "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp明德小学校长集中研修后，学校要制定未来一年的学校发展计划（以下简称SDP）。学校在发展计划的制定及执行过程中，各省指导小组要通过管理平台、实地指导、校长联谊会等途径，及时进行帮助支持，以解决学校在教学、管理等方面出现的问题。";
        LbTemplatesContent.Text += "<br>";
        LbTemplatesContent.Text += "<br>";
        LbTemplatesContent.Text += "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp各省专家小组到目标学校根据行动计划进行实地指导，同时，专家小组也承担对 SDP 监测评估的责任。专家小组在下校指导时要注意以下几点：一是要明确工作指导思想，要力戒、避免形式主义；二是“用事实说话”，通过一些相关部门的评审、评奖，说明学校的变化、提升，以及学校的创新与特色（例如,禹州市范坡镇朱集明德小学由原来学区的第六名，一跃成为第二名）；三是关注学校的变化，重在比较，用目标学校的今天比较它的昨天，更要与非明德同类优秀学校比较，缩小差距，勇于赶超，使之成为当地的标杆学校。";
        LbTemplatesContent.Text += "<br>";
        LbTemplatesContent.Text += "<br>";
        LbTemplatesContent.Text += "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp各省后期跟踪指导报告应按照以下提示撰写报告。报告完成后请删除所有提示，另存为报告XX ，保留模板下次使用。执行／监测报告必须严格遵循模板要求，每次下校实地指导后撰写报告一份。";
    }
    protected void BtnTemplateReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("GuideList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString());
    }
<<<<<<< HEAD
=======
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            Response.Redirect("../ProvinceIndex.aspx");
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            Response.Redirect("../MingdeIndex.aspx");
        }
    }
>>>>>>> develop
}