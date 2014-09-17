<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grid.aspx.cs" Inherits="WebApplication1.Grid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Ext_4.2/resources/css/ext-all-neptune.css" rel="stylesheet" />
    <script src="Ext_4.2/bootstrap.js"></script>
    <title></title>
    <%-- <script src="Ext_4.2/ext-all.js"></script>--%>
    <script type="text/javascript">
        Ext.onReady(function () {


            Ext.define('FiledModel', {
                extend: 'Ext.data.Model',
                fields: [{
                    name: "common", type: "string"
                }
     , {
         name: "botanical", type: "string"
     }
     , {
         name: "light"
     }
     , {
         name: "price", type: "float"
     }
     , {
         name: "availDate", mapping: "availability", type: "date", dateFormat: "m/d/Y"
     }
     , {
         name: "indoor", type: "bool"
     }
                ]
            });

            Ext.define('grid', {
                extend: 'Ext.grid.Panel',

                requires: [
                    'Ext.selection.CellModel',
                    'Ext.grid.*',
                    'Ext.data.*',
                    'Ext.util.*',
                    'Ext.form.*',
                    'FiledModel'
                ],
                xtype: 'cell-editing',

                //<example>
                exampleTitle: 'Cell Editing Grid Example',
                exampleDescription: [
                    '<p>This example shows how to enable users to edit the contents of a grid.</p>'
                ].join(''),
                themes: {
                    classic: {
                        width: 600,
                        height: 300,
                        indoorWidth: 55
                    },
                    neptune: {
                        width: 680,
                        height: 350,
                        indoorWidth: 90
                    }
                },
                //</example>

                title: 'Edit Plants',
                frame: true,

                initComponent: function () {
                    this.cellEditing = new Ext.grid.plugin.CellEditing({
                        clicksToEdit: 1
                    });

                    Ext.apply(this, {
                        width: 800,
                        height: 600,
                        plugins: [this.cellEditing],
                        store: new Ext.data.Store({
                            // destroy the store if the grid is destroyed
                            autoDestroy: true,
                            model: FiledModel,
                            proxy: {
                                type: 'ajax',
                                // load remote data using HTTP
                                url: 'plants.xml',
                                // specify a XmlReader (coincides with the XML format of the returned data)
                                reader: {
                                    type: 'xml',
                                    // records will have a 'plant' tag
                                    record: 'plant'
                                }
                            },
                            sorters: [{
                                property: 'common',
                                direction: 'ASC'
                            }]
                        }),
                        columns: [{
                            header: 'Common Name',
                            dataIndex: 'common',
                            flex: 1,
                            editor: {
                                allowBlank: false
                            }
                        }, {
                            header: 'Light',
                            dataIndex: 'light',
                            width: 130,
                            editor: new Ext.form.field.ComboBox({
                                typeAhead: true,
                                triggerAction: 'all',
                                store: [
                                    ['Shade', 'Shade'],
                                    ['Mostly Shady', 'Mostly Shady'],
                                    ['Sun or Shade', 'Sun or Shade'],
                                    ['Mostly Sunny', 'Mostly Sunny'],
                                    ['Sunny', 'Sunny']
                                ]
                            })
                        }, {
                            header: 'Price',
                            dataIndex: 'price',
                            width: 70,
                            align: 'right',
                            renderer: 'usMoney',
                            editor: {
                                xtype: 'numberfield',
                                allowBlank: false,
                                minValue: 0,
                                maxValue: 100000
                            }
                        }, {
                            header: 'Available',
                            dataIndex: 'availDate',
                            width: 95,
                            renderer: Ext.util.Format.dateRenderer('M d, Y'),
                            editor: {
                                xtype: 'datefield',
                                format: 'm/d/y',
                                minValue: '01/01/06',
                                disabledDays: [0, 6],
                                disabledDaysText: 'Plants are not available on the weekends'
                            }
                        }, {
                            xtype: 'checkcolumn',
                            header: 'Indoor?',
                            dataIndex: 'indoor',
                            width: 100,
                            stopSelection: false
                        }, {
                            xtype: 'actioncolumn',
                            width: 30,
                            sortable: false,
                            menuDisabled: true,
                            items: [{
                                icon: '/Ext_4.2/shared/icons/fam/delete.gif',
                                tooltip: 'Delete Plant',
                                scope: this,
                                handler: this.onRemoveClick
                            }]
                        }],
                        selModel: {
                            selType: 'cellmodel'
                        },
                        tbar: [{
                            text: 'Add Plant',
                            scope: this,
                            handler: this.onAddClick
                        }]
                    });

                    this.callParent();

                    this.on('afterlayout', this.loadStore, this, {
                        delay: 1,
                        single: true
                    })
                },

                loadStore: function () {
                    this.getStore().load({
                        // store loading is asynchronous, use a load listener or callback to handle results
                        callback: this.onStoreLoad
                    });
                },

                onStoreLoad: function () {
                    Ext.Msg.show({
                        title: 'Store Load Callback',
                        msg: 'store was loaded, data available for processing',
                        icon: Ext.Msg.INFO,
                        buttons: Ext.Msg.OK
                    });
                },

                onAddClick: function () {
                    // Create a model instance
                    var rec = new KitchenSink.model.grid.Plant({
                        common: 'New Plant 1',
                        light: 'Mostly Shady',
                        price: 0,
                        availDate: Ext.Date.clearTime(new Date()),
                        indoor: false
                    });

                    this.getStore().insert(0, rec);
                    this.cellEditing.startEditByPosition({
                        row: 0,
                        column: 0
                    });
                },

                onRemoveClick: function (grid, rowIndex) {
                    this.getStore().removeAt(rowIndex);
                }
            })

            // 页面视图
            viewport = new Ext.Viewport({
                items: [grid]
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
