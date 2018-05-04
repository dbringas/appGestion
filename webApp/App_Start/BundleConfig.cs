using System.Web;
using System.Web.Optimization;

namespace webApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Vendor scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery/jquery-1.11.1.min.js"));

            // jQuery confirm
            bundles.Add(new ScriptBundle("~/bundles/confirmacion").Include("~/Scripts/jquery.confirm/jquery.confirm.min.js"));

            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap/bootstrap.min.js"));

            // Inspinia script
            bundles.Add(new ScriptBundle("~/bundles/inspinia").Include("~/Scripts/app/inspinia.js"));

            // SlimScroll
            bundles.Add(new ScriptBundle("~/plugins/slimScroll").Include("~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js"));

            // jQuery plugins
            bundles.Add(new ScriptBundle("~/plugins/metsiMenu").Include("~/Scripts/plugins/metisMenu/metisMenu.min.js"));
            bundles.Add(new ScriptBundle("~/plugins/pace").Include("~/Scripts/plugins/pace/pace.min.js"));

            // Date
            bundles.Add(new ScriptBundle("~/plugins/date").Include("~/Scripts/plugins/date/date.js"));

            // Table2Excel
            bundles.Add(new ScriptBundle("~/plugins/table2excel").Include("~/Scripts/plugins/table2excel/table2excel.mins.js"));

            // Font Awesome icons
            bundles.Add(new StyleBundle("~/font-awesome/css").Include("~/Fonts/font-awesome/css/font-awesome.min.css"));

            // CSS style (bootstrap/inspinia)
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap/bootstrap.min.css",
                                                                 "~/Content/animate/animate.css",
                                                                 "~/Content/style.css"));

            // CSS style (jquery confirm)
            bundles.Add(new StyleBundle("~/Content/confirmacion").Include("~/Content/jquery.confirm/jquery.confirm.min.css"));

            // CSS style (jqwidgets)
            bundles.Add(new StyleBundle("~/Content/jqwidgets").Include("~/Content/jqwidgets/jqx.base.css",
                                                                       "~/Content/jqwidgets/jqx.bootstrap.css",
                                                                       "~/Content/jqwidgets.custom.css"));

            // JQWidgets
            bundles.Add(new ScriptBundle("~/bundles/jqwidgets").Include("~/Scripts/jqwidgets/jqxcore.js",
                                                                        "~/Scripts/jqwidgets/jqxdata.js",
                                                                        "~/Scripts/jqwidgets/jqxinput.js",
                                                                        "~/Scripts/jqwidgets/jqxpasswordinput.js",
                                                                        "~/Scripts/jqwidgets/jqxbuttons.js",
                                                                        "~/Scripts/jqwidgets/jqxscrollbar.js",
                                                                        "~/Scripts/jqwidgets/jqxmenu.js",
                                                                        "~/Scripts/jqwidgets/jqxcheckbox.js",
                                                                        "~/Scripts/jqwidgets/jqxradiobutton.js",
                                                                        "~/Scripts/jqwidgets/jqxlistbox.js",
                                                                        "~/Scripts/jqwidgets/jqxdropdownlist.js",
                                                                        "~/Scripts/jqwidgets/jqxcombobox.js",
                                                                        "~/Scripts/jqwidgets/jqxgrid.js",
                                                                        "~/Scripts/jqwidgets/jqxgrid.selection.js",
                                                                        "~/Scripts/jqwidgets/jqxgrid.edit.js",
                                                                        "~/Scripts/jqwidgets/jqxgrid.columnsresize.js",
                                                                        "~/Scripts/jqwidgets/jqxgrid.sort.js",
                                                                        "~/Scripts/jqwidgets/jqxgrid.filter.js",
                                                                        "~/Scripts/jqwidgets/jqxgrid.aggregates.js",
                                                                        "~/Scripts/jqwidgets/jqxgrid.grouping.js",
                                                                        "~/Scripts/jqwidgets/jqxnumberinput.js",
                                                                        "~/Scripts/jqwidgets/jqxdatetimeinput.js",
                                                                        "~/Scripts/jqwidgets/jqxcalendar.js",
                                                                        "~/Scripts/jqwidgets/jqxtooltip.js",
                                                                        "~/Scripts/jqwidgets/jqxdraw.js",
                                                                        "~/Scripts/jqwidgets/jqxchart.core.js",
                                                                        "~/Scripts/jqwidgets/jqxtree.js",
                                                                        "~/Scripts/jqwidgets/globalization/globalize.js",
                                                                        "~/Scripts/jqwidgets/globalization/globalize.culture.es-PE.js",
                                                                        "~/Scripts/jqwidgets/localization.js",
                                                                        "~/Scripts/jqwidgets.custom.js"));

            // Scripts personalizados
            bundles.Add(new ScriptBundle("~/bundles/custom").Include("~/Scripts/custom.js"));
        }
    }
}
