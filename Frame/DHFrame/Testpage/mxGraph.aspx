<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mxGraph.aspx.cs" Inherits="HDFrame.gxGraph" %>

<html>
<head>
    <title>Toolbar example for mxGraph</title>
    <meta http-equiv="X-UA-Compatible" content="IE=9">
    <!-- Sets the basepath for the library if not in same directory -->
    <script type="text/javascript">
        mxBasePath = 'mxGraph/src';
    </script>

    <!-- Loads and initializes the library -->
    <script src="mxGraph/debug/js/mxClient.js"></script>
    <!-- Example code -->
    <script type="text/javascript">

        function main() {
            // Defines an icon for creating new connections in the connection handler.
            // This will automatically disable the highlighting of the source vertex.
            mxConnectionHandler.prototype.connectImage = new mxImage('mxGraph/examples/images/connector.gif', 16, 16);

            // Creates the div for the toolbar
            var tbContainer = document.createElement('div');
            tbContainer.style.position = 'absolute';
            tbContainer.style.overflow = 'hidden';
            tbContainer.style.padding = '2px';
            tbContainer.style.left = '0px';
            tbContainer.style.top = '26px';
            tbContainer.style.width = '24px';
            tbContainer.style.bottom = '0px';

            document.body.appendChild(tbContainer);

            // Workaround for Internet Explorer ignoring certain styles
            //if (mxClient.IS_IE) {
            //  new mxDivResizer(tbContainer);
            //}

            // Creates new toolbar without event processing
            var toolbar = new mxToolbar(tbContainer);
            toolbar.enabled = false

            // Creates the div for the graph
            container = document.createElement('div');
            container.style.position = 'absolute';
            container.style.overflow = 'hidden';
            container.style.left = '50px';
            container.style.top = '40px';
            container.style.right = '0px';
            container.style.bottom = '0px';
            container.style.background = 'url("mxGraph/examples/editors/images/grid.gif")';

            document.body.appendChild(container);

            // Workaround for Internet Explorer ignoring certain styles
            //if (mxClient.IS_IE) {
            //    new mxDivResizer(container);
            //}

            // Creates the model and the graph inside the container
            // using the fastest rendering available on the browser
            var model = new mxGraphModel();
            var graph = new mxGraph(container, model);

            // Enables new connections in the graph
            graph.setConnectable(true);
            graph.setMultigraph(false);

            // Stops editing on enter or escape keypress
            var keyHandler = new mxKeyHandler(graph);
            var rubberband = new mxRubberband(graph);

            var addVertex = function (icon, w, h, style) {
                var vertex = new mxCell(null, new mxGeometry(0, 0, w, h), style);
                vertex.setVertex(true); //设置顶点
                addToolbarItem(graph, toolbar, vertex, icon);
            };

            addVertex('mxGraph/examples/editors/images/rectangle.gif', 100, 40, '');
            addVertex('mxGraph/examples/editors/images/rounded.gif', 100, 40, 'shape=rounded');
            addVertex('mxGraph/examples/editors/images/ellipse.gif', 40, 40, 'shape=ellipse');
            addVertex('mxGraph/examples/editors/images/rhombus.gif', 40, 40, 'shape=rhombus');
            addVertex('mxGraph/examples/editors/images/triangle.gif', 40, 40, 'shape=triangle');
            addVertex('mxGraph/examples/editors/images/cylinder.gif', 40, 40, 'shape=cylinder');
            addVertex('mxGraph/examples/editors/images/actor.gif', 30, 40, 'shape=actor');
            addVertex('mxGraph/examples/editors/images/straight.gif', 30, 40, 'shape=line');
            //toolbar.addLine(); //添加分割线

            var button = mxUtils.button('删除', function (evt) {
                if (!graph.isSelectionEmpty()) {
                    // Creates a copy of the selection array to preserve its state
                    var cells = graph.getSelectionCells();
                    var bounds = graph.getView().getBounds(cells);//返回边界

                    // Function that is executed when the image is dropped on
                    // the graph. The cell argument points to the cell under
                    // the mousepointer if there is one.
                    //var funct = function (graph, evt, cell) {
                    //    graph.stopEditing(false);

                    //    var pt = graph.getPointForEvent(evt);
                    //    var dx = pt.x - bounds.x;
                    //    var dy = pt.y - bounds.y;

                    //    var clones = graph.importCells(cells, dx, dy); //导入cell 
                    //    graph.setSelectionCells(clones);
                    //}

                    //// Creates the image which is used as the drag icon (preview)
                    //var img = toolbar.addMode(null, 'mxGraph/examples/editors/images/outline.gif', funct);

                    //Configures the given DOM element to act as a drag source for the specified graph.
                    //mxUtils.makeDraggable(img, graph, funct);
                    graph.removeCells();
                }
            });

            //hock delete key 
            var keyHandler = new mxKeyHandler(graph);
            keyHandler.bindKey(46, function (evt) {
                if (graph.isEnabled()) {
                    graph.removeCells();
                }
            });

            //button.style.position = 'absolute';
            //button.style.left = '2px';
            //button.style.top = '2px';
            document.body.appendChild(button);

            var btnXml = mxUtils.button('XML', function (evt) {
                if (!graph.isSelectionEmpty()) {

                    var enc1 = new mxCodec(mxUtils.createXmlDocument());
                    var node1 = enc1.encode(graph.getModel());
                    var xml1 = mxUtils.getXml(node1);
                    alert(xml1);
                }
            });

            //btnXml.style.position = 'absolute';
            //btnXml.style.left = '55px';
            //btnXml.style.top = '2px';
            document.body.appendChild(btnXml);

            //------------------以下是测试demo-------------------
            text1(graph, model);
            //canvasDraw(graph);
            guides(graph, container);

            //-------------------按钮功能------------------------
            var currentPermission = null;
            var apply = function (permission) {
                graph.clearSelection();
                permission.apply(graph);
                graph.setEnabled(true);
                graph.setTooltips(true);

                // Updates the icons on the shapes - rarely
                // needed and very slow for large graphs
                graph.refresh();
                currentPermission = permission;
            };

            apply(new Permission());

            var button = mxUtils.button('Allow All', function (evt) {
                apply(new Permission());
            });
            document.body.appendChild(button);

            var button = mxUtils.button('Connect Only', function (evt) {
                apply(new Permission(false, true, false, false, true));
            });
            document.body.appendChild(button);

            var button = mxUtils.button('Edges Only', function (evt) {
                apply(new Permission(false, false, true, false, false));
            });
            document.body.appendChild(button);

            var button = mxUtils.button('Vertices Only', function (evt) {
                apply(new Permission(false, false, false, true, false));
            });
            document.body.appendChild(button);

            var button = mxUtils.button('Select Only', function (evt) {
                apply(new Permission(false, false, false, false, false));
            });
            document.body.appendChild(button);

            var button = mxUtils.button('Locked', function (evt) {
                apply(new Permission(true, false));
            });
            document.body.appendChild(button);

            var button = mxUtils.button('Disabled', function (evt) {
                graph.clearSelection();
                graph.setEnabled(false);
                graph.setTooltips(false);
            });
            document.body.appendChild(button);

            //---------group---------------------------
            //new mxRubberband(graph); 这句没起作用

            var parent = graph.getDefaultParent();
            // Adds cells to the model in a single step
            graph.getModel().beginUpdate();
            try {
                var v1 = graph.insertVertex(parent, null, 'Hello,', 220, 20, 120, 60);
                var v2 = graph.insertVertex(v1, null, 'World!', 90, 20, 60, 20);
            }
            finally {
                // Updates the display
                graph.getModel().endUpdate();
            }
        }

        /*键盘移动*/
        function guides(graph, container) {

            // Enables guides
            mxGraphHandler.prototype.guidesEnabled = true;

            // Alt disables guides
            mxGraphHandler.prototype.useGuidesForEvent = function (me) {
                return !mxEvent.isAltDown(me.getEvent());
            };

            // Defines the guides to be red (default)
            mxConstants.GUIDE_COLOR = '#FF0000';

            // Defines the guides to be 1 pixel (default)
            mxConstants.GUIDE_STROKEWIDTH = 1;

            // Enables snapping waypoints to terminals
            mxEdgeHandler.prototype.snapToTerminals = true;

            // Enables crisp rendering of rectangles in SVG
            mxRectangleShape.prototype.crisp = true;

            // Creates the graph inside the given container
            // var graph = new mxGraph(container);
            graph.setConnectable(true);
            graph.gridSize = 30;

            // Changes the default style for edges "in-place" and assigns
            // an alternate edge style which is applied in mxGraph.flip
            // when the user double clicks on the adjustment control point
            // of the edge. The ElbowConnector edge style switches to TopToBottom
            // if the horizontal style is true.
            var style = graph.getStylesheet().getDefaultEdgeStyle();
            style[mxConstants.STYLE_ROUNDED] = true;
            style[mxConstants.STYLE_EDGE] = mxEdgeStyle.ElbowConnector;
            graph.alternateEdgeStyle = 'elbow=vertical';

            // Enables rubberband selection
            new mxRubberband(graph);

            // Gets the default parent for inserting new cells. This
            // is normally the first child of the root (ie. layer 0).
            var parent = graph.getDefaultParent();

            // Adds cells to the model in a single step
            graph.getModel().beginUpdate();
            var v1;
            try {
                v1 = graph.insertVertex(parent, null, 'Hello,', 20, 150, 80, 70);
                var v2 = graph.insertVertex(parent, null, 'World!', 150, 340, 80, 40);
                var e1 = graph.insertEdge(parent, null, '', v1, v2);
            }
            finally {
                // Updates the display
                graph.getModel().endUpdate();
            }

            // Handles cursor keys
            var nudge = function (keyCode) {
                if (!graph.isSelectionEmpty()) {
                    var dx = 0;
                    var dy = 0;

                    if (keyCode == 37) {
                        dx = -1;
                    }
                    else if (keyCode == 38) {
                        dy = -1;
                    }
                    else if (keyCode == 39) {
                        dx = 1;
                    }
                    else if (keyCode == 40) {
                        dy = 1;
                    }

                    graph.moveCells(graph.getSelectionCells(), dx, dy);
                }
            };

            // Transfer initial focus to graph container for keystroke handling
            graph.container.focus();

            // Handles keystroke events
            var keyHandler = new mxKeyHandler(graph);

            // Ignores enter keystroke. Remove this line if you want the
            // enter keystroke to stop editing
            keyHandler.enter = function () { };

            keyHandler.bindKey(37, function () {
                nudge(37);
            });

            keyHandler.bindKey(38, function () {
                nudge(38);
            });

            keyHandler.bindKey(39, function () {
                nudge(39);
            });

            keyHandler.bindKey(40, function () {
                nudge(40);
            });
        }

        //第一个测试
        function text1(graph, model) {

            //这通常是根节点的第一个子节点
            var parent = graph.getDefaultParent();

            // Adds cells to the model in a single step
            model.beginUpdate();
            try {
                var v1 = graph.insertVertex(parent, null, 'Hello,', 20, 20, 80, 30);
                var v2 = graph.insertVertex(parent, null, 'World!', 200, 150, 80, 30);
                var e1 = graph.insertEdge(parent, null, '', v1, v2);

            }
            finally {
                //更新显示
                model.endUpdate();
            }
            //实例化对象到xml中
            //var object = new Object();
            //object.myBool = true;
            //object.myObject = new Object();
            //object.myObject.name = 'Test';
            //object.myArray = ['a', ['b', 'c'], 'd'];

            //var encoder = new mxCodec();
            //var node = encoder.encode(object);
            //mxUtils.popup(mxUtils.getXml(node)); //弹出窗口

        }

        function addToolbarItem(graph, toolbar, prototype, image) {
            // Function that is executed when the image is dropped on
            // the graph. The cell argument points to the cell under
            // the mousepointer if there is one.
            var funct = function (graph, evt, cell) {
                graph.stopEditing(false);

                var pt = graph.getPointForEvent(evt);
                var vertex = graph.getModel().cloneCell(prototype);
                vertex.geometry.x = pt.x;
                vertex.geometry.y = pt.y;

                graph.addCell(vertex);
                graph.setSelectionCell(vertex);
            }

            // Creates the image which is used as the drag icon (preview)
            var img = toolbar.addMode(null, image, funct);
            mxUtils.makeDraggable(img, graph, funct);
        }

        function Permission(locked, createEdges, editEdges, editVertices, cloneCells) {
            this.locked = (locked != null) ? locked : false;
            this.createEdges = (createEdges != null) ? createEdges : true;
            this.editEdges = (editEdges != null) ? editEdges : true;;
            this.editVertices = (editVertices != null) ? editVertices : true;;
            this.cloneCells = (cloneCells != null) ? cloneCells : true;;
        };

        Permission.prototype.apply = function (graph) {
            graph.setConnectable(this.createEdges);
            graph.setCellsLocked(this.locked);
        };
    </script>
</head>

<!-- Calls the main function after the page has loaded. Container is dynamically created. -->
<body onload="main();">
    <div id="id-of-graph-container"></div>
</body>
</html>

