use FireTankAdmin

insert into UserModels values (NEWID(), 'Имя', 'Отчество', 'Фамилия', 'admin','admin')

insert into MapModels values (NEWID(), CONVERT(XML, '<?xml version="1.0" encoding="UTF-8"?>
<map version="1.0" orientation="orthogonal" renderorder="right-down" width="16" height="16" tilewidth="32" tileheight="32" nextobjectid="147">
 <properties>
  <property name="algorithm" value=""/>
  <property name="wind" value="left"/>
 </properties>
 <tileset firstgid="1" name="Sprites" tilewidth="32" tileheight="32" tilecount="25" columns="5">
  <image source="Sprites.png" width="160" height="160"/>
 </tileset>
 <layer name="terrain" width="16" height="16">
  <data>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
  </data>
 </layer>
 <objectgroup name="tanks">
  <object id="52" name="tank" type="tank" gid="20" x="448" y="352" width="32" height="32" rotation="-90">
   <properties>
    <property name="capacity" type="int" value="4"/>
    <property name="maxCapacity" type="int" value="5"/>
    <property name="maxPressure" type="int" value="5"/>
   </properties>
  </object>
  <object id="53" name="tank" type="tank" gid="20" x="96" y="256" width="32" height="32" rotation="-270">
   <properties>
    <property name="capacity" type="int" value="4"/>
    <property name="maxCapacity" type="int" value="5"/>
    <property name="maxPressure" type="int" value="5"/>
   </properties>
  </object>
  <object id="138" name="tank" type="tank" gid="20" x="96" y="64" width="32" height="32" rotation="-270">
   <properties>
    <property name="capacity" type="int" value="4"/>
    <property name="maxCapacity" type="int" value="5"/>
    <property name="maxPressure" type="int" value="5"/>
   </properties>
  </object>
 </objectgroup>
 <objectgroup name="turrets">
  <object id="54" name="turret" type="turret" gid="21" x="448" y="352" width="32" height="32" rotation="-90"/>
  <object id="55" name="turret" type="turret" gid="21" x="96" y="256" width="32" height="32" rotation="90"/>
  <object id="139" name="turret" type="turret" gid="21" x="96" y="64" width="32" height="32" rotation="-270"/>
 </objectgroup>
 <objectgroup name="trees">
  <object id="77" name="tree" type="tree" gid="6" x="320" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="78" name="tree" type="tree" gid="6" x="320" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="79" name="tree" type="tree" gid="6" x="384" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="80" name="tree" type="tree" gid="6" x="256" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="81" name="tree" type="tree" gid="6" x="160" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="82" name="tree" type="tree" gid="6" x="320" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="83" name="tree" type="tree" gid="6" x="64" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="84" name="tree" type="tree" gid="6" x="288" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="85" name="tree" type="tree" gid="6" x="288" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="86" name="tree" type="tree" gid="6" x="352" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="87" name="tree" type="tree" gid="6" x="192" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="88" name="tree" type="tree" gid="6" x="256" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="89" name="tree" type="tree" gid="6" x="224" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="90" name="tree" type="tree" gid="6" x="288" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="91" name="tree" type="tree" gid="6" x="352" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="92" name="tree" type="tree" gid="6" x="224" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="93" name="tree" type="tree" gid="6" x="96" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="94" name="tree" type="tree" gid="6" x="128" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="95" name="tree" type="tree" gid="6" x="352" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="117" name="tree" type="tree" gid="6" x="256" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="118" name="tree" type="tree" gid="6" x="288" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="119" name="tree" type="tree" gid="6" x="160" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="120" name="tree" type="tree" gid="6" x="256" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="121" name="tree" type="tree" gid="6" x="288" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="122" name="tree" type="tree" gid="6" x="256" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="123" name="tree" type="tree" gid="6" x="320" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="124" name="tree" type="tree" gid="6" x="192" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="125" name="tree" type="tree" gid="6" x="320" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="126" name="tree" type="tree" gid="6" x="160" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="127" name="tree" type="tree" gid="6" x="256" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="128" name="tree" type="tree" gid="6" x="224" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="129" name="tree" type="tree" gid="6" x="320" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="130" name="tree" type="tree" gid="6" x="128" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="131" name="tree" type="tree" gid="6" x="128" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="132" name="tree" type="tree" gid="6" x="192" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="133" name="tree" type="tree" gid="6" x="352" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="134" name="tree" type="tree" gid="6" x="192" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="135" name="tree" type="tree" gid="6" x="288" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="136" name="tree" type="tree" gid="6" x="288" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="137" name="tree" type="tree" gid="6" x="224" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="140" name="tree" type="tree" gid="6" x="256" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="141" name="tree" type="tree" gid="6" x="256" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="142" name="tree" type="tree" gid="6" x="288" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="143" name="tree" type="tree" gid="6" x="320" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="144" name="tree" type="tree" gid="6" x="288" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="145" name="tree" type="tree" gid="6" x="320" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="146" name="tree" type="tree" gid="6" x="224" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
 </objectgroup>
</map>
', 2))

insert into MapModels values (NEWID(), CONVERT(XML, '<?xml version="1.0" encoding="UTF-8"?>
<map version="1.0" orientation="orthogonal" renderorder="right-down" width="16" height="16" tilewidth="32" tileheight="32" nextobjectid="240">
 <properties>
  <property name="algorithm" value=""/>
  <property name="wind" value="up"/>
 </properties>
 <tileset firstgid="1" name="Sprites" tilewidth="32" tileheight="32" tilecount="25" columns="5">
  <image source="Sprites.png" width="160" height="160"/>
 </tileset>
 <layer name="terrain" width="16" height="16">
  <data>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
  </data>
 </layer>
 <objectgroup name="houses">
  <object id="234" name="house" type="house" gid="25" x="256" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="15"/>
   </properties>
  </object>
  <object id="235" name="house" type="house" gid="25" x="256" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="15"/>
   </properties>
  </object>
  <object id="236" name="house" type="house" gid="25" x="448" y="352" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="15"/>
   </properties>
  </object>
  <object id="237" name="house" type="house" gid="25" x="448" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="15"/>
   </properties>
  </object>
  <object id="238" name="house" type="house" gid="25" x="256" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="15"/>
   </properties>
  </object>
 </objectgroup>
 <objectgroup name="rocks">
  <object id="216" name="rock" type="rock" gid="23" x="320" y="448" width="32" height="32"/>
  <object id="217" name="rock" type="rock" gid="23" x="288" y="448" width="32" height="32"/>
  <object id="218" name="rock" type="rock" gid="23" x="320" y="416" width="32" height="32"/>
  <object id="219" name="rock" type="rock" gid="23" x="160" y="128" width="32" height="32"/>
  <object id="220" name="rock" type="rock" gid="23" x="128" y="128" width="32" height="32"/>
  <object id="221" name="rock" type="rock" gid="23" x="96" y="128" width="32" height="32"/>
  <object id="222" name="rock" type="rock" gid="23" x="128" y="96" width="32" height="32"/>
  <object id="223" name="rock" type="rock" gid="23" x="96" y="96" width="32" height="32"/>
  <object id="224" name="rock" type="rock" gid="23" x="64" y="96" width="32" height="32"/>
  <object id="225" name="rock" type="rock" gid="23" x="448" y="64" width="32" height="32"/>
  <object id="226" name="rock" type="rock" gid="23" x="416" y="64" width="32" height="32"/>
  <object id="227" name="rock" type="rock" gid="23" x="448" y="96" width="32" height="32"/>
  <object id="228" name="rock" type="rock" gid="23" x="448" y="128" width="32" height="32"/>
  <object id="229" name="rock" type="rock" gid="23" x="416" y="96" width="32" height="32"/>
  <object id="230" name="rock" type="rock" gid="23" x="32" y="352" width="32" height="32"/>
  <object id="231" name="rock" type="rock" gid="23" x="64" y="352" width="32" height="32"/>
  <object id="232" name="rock" type="rock" gid="23" x="64" y="384" width="32" height="32"/>
  <object id="233" name="rock" type="rock" gid="23" x="32" y="320" width="32" height="32"/>
 </objectgroup>
 <objectgroup name="lakes">
  <object id="208" name="lake" type="lake" gid="22" x="384" y="480" width="32" height="32"/>
  <object id="209" name="lake" type="lake" gid="22" x="384" y="448" width="32" height="32"/>
  <object id="210" name="lake" type="lake" gid="22" x="416" y="416" width="32" height="32"/>
  <object id="211" name="lake" type="lake" gid="22" x="384" y="416" width="32" height="32"/>
  <object id="212" name="lake" type="lake" gid="22" x="416" y="448" width="32" height="32"/>
  <object id="213" name="lake" type="lake" gid="22" x="128" y="320" width="32" height="32"/>
  <object id="214" name="lake" type="lake" gid="22" x="96" y="320" width="32" height="32"/>
  <object id="215" name="lake" type="lake" gid="22" x="64" y="320" width="32" height="32"/>
 </objectgroup>
 <objectgroup name="tanks">
  <object id="52" name="tank" type="tank" gid="20" x="416" y="352" width="32" height="32" rotation="-90">
   <properties>
    <property name="capacity" type="int" value="4"/>
    <property name="maxCapacity" type="int" value="7"/>
    <property name="maxPressure" type="int" value="5"/>
   </properties>
  </object>
  <object id="53" name="tank" type="tank" gid="20" x="192" y="448" width="32" height="32" rotation="-360">
   <properties>
    <property name="capacity" type="int" value="4"/>
    <property name="maxCapacity" type="int" value="7"/>
    <property name="maxPressure" type="int" value="5"/>
   </properties>
  </object>
  <object id="138" name="tank" type="tank" gid="20" x="224" y="64" width="32" height="32" rotation="-540">
   <properties>
    <property name="capacity" type="int" value="4"/>
    <property name="maxCapacity" type="int" value="7"/>
    <property name="maxPressure" type="int" value="5"/>
   </properties>
  </object>
  <object id="203" name="tank" type="tank" gid="20" x="288" y="128" width="32" height="32" rotation="-540">
   <properties>
    <property name="capacity" type="int" value="4"/>
    <property name="maxCapacity" type="int" value="7"/>
    <property name="maxPressure" type="int" value="5"/>
   </properties>
  </object>
 </objectgroup>
 <objectgroup name="turrets">
  <object id="204" name="turret" type="turret" gid="21" x="416" y="352" width="32" height="32" rotation="-90"/>
  <object id="205" name="turret" type="turret" gid="21" x="192" y="448" width="32" height="32" rotation="-360"/>
  <object id="206" name="turret" type="turret" gid="21" x="224" y="64" width="32" height="32" rotation="-540"/>
  <object id="207" name="turret" type="turret" gid="21" x="288" y="128" width="32" height="32" rotation="-540"/>
 </objectgroup>
 <objectgroup name="trees">
  <object id="147" name="tree" type="tree" gid="6" x="352" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="148" name="tree" type="tree" gid="6" x="384" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="149" name="tree" type="tree" gid="6" x="384" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="150" name="tree" type="tree" gid="6" x="384" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="151" name="tree" type="tree" gid="6" x="352" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="152" name="tree" type="tree" gid="6" x="352" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="153" name="tree" type="tree" gid="6" x="384" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="154" name="tree" type="tree" gid="6" x="416" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="155" name="tree" type="tree" gid="6" x="384" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="156" name="tree" type="tree" gid="6" x="416" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="157" name="tree" type="tree" gid="6" x="352" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="158" name="tree" type="tree" gid="6" x="384" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="159" name="tree" type="tree" gid="6" x="416" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="160" name="tree" type="tree" gid="6" x="352" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="161" name="tree" type="tree" gid="6" x="320" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="162" name="tree" type="tree" gid="6" x="320" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="163" name="tree" type="tree" gid="6" x="256" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="164" name="tree" type="tree" gid="6" x="288" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="165" name="tree" type="tree" gid="6" x="288" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="166" name="tree" type="tree" gid="6" x="256" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="167" name="tree" type="tree" gid="6" x="224" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="168" name="tree" type="tree" gid="6" x="256" y="352" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="169" name="tree" type="tree" gid="6" x="288" y="352" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="170" name="tree" type="tree" gid="6" x="288" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="171" name="tree" type="tree" gid="6" x="256" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="172" name="tree" type="tree" gid="6" x="256" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="173" name="tree" type="tree" gid="6" x="224" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="174" name="tree" type="tree" gid="6" x="224" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="175" name="tree" type="tree" gid="6" x="192" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="176" name="tree" type="tree" gid="6" x="224" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="177" name="tree" type="tree" gid="6" x="192" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="178" name="tree" type="tree" gid="6" x="224" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="179" name="tree" type="tree" gid="6" x="192" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="180" name="tree" type="tree" gid="6" x="96" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="181" name="tree" type="tree" gid="6" x="96" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="182" name="tree" type="tree" gid="6" x="128" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="183" name="tree" type="tree" gid="6" x="128" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="184" name="tree" type="tree" gid="6" x="96" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="185" name="tree" type="tree" gid="6" x="64" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="186" name="tree" type="tree" gid="6" x="64" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="187" name="tree" type="tree" gid="6" x="64" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="188" name="tree" type="tree" gid="6" x="64" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="189" name="tree" type="tree" gid="6" x="96" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="190" name="tree" type="tree" gid="6" x="96" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="191" name="tree" type="tree" gid="6" x="96" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="192" name="tree" type="tree" gid="6" x="128" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="193" name="tree" type="tree" gid="6" x="128" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="194" name="tree" type="tree" gid="6" x="128" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="195" name="tree" type="tree" gid="6" x="96" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="196" name="tree" type="tree" gid="6" x="64" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="197" name="tree" type="tree" gid="6" x="64" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="198" name="tree" type="tree" gid="6" x="352" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="199" name="tree" type="tree" gid="6" x="320" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="200" name="tree" type="tree" gid="6" x="320" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="201" name="tree" type="tree" gid="6" x="384" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="202" name="tree" type="tree" gid="6" x="416" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="239" name="tree" type="tree" gid="6" x="256" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
 </objectgroup>
</map>
', 2))

insert into MapModels values (NEWID(), CONVERT(XML, '<?xml version="1.0" encoding="UTF-8"?>
<map version="1.0" orientation="orthogonal" renderorder="right-down" width="24" height="24" tilewidth="32" tileheight="32" nextobjectid="374">
 <properties>
  <property name="algorithm" value=""/>
  <property name="wind" value="right"/>
 </properties>
 <tileset firstgid="1" name="Sprites" tilewidth="32" tileheight="32" tilecount="25" columns="5">
  <image source="Sprites.png" width="160" height="160"/>
 </tileset>
 <layer name="terrain" width="24" height="24">
  <data>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="11"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
  </data>
 </layer>
 <objectgroup name="lakes">
  <object id="208" name="lake" type="lake" gid="22" x="448" y="608" width="32" height="32"/>
  <object id="209" name="lake" type="lake" gid="22" x="480" y="608" width="32" height="32"/>
  <object id="210" name="lake" type="lake" gid="22" x="512" y="576" width="32" height="32"/>
  <object id="211" name="lake" type="lake" gid="22" x="512" y="608" width="32" height="32"/>
  <object id="212" name="lake" type="lake" gid="22" x="480" y="576" width="32" height="32"/>
  <object id="213" name="lake" type="lake" gid="22" x="128" y="320" width="32" height="32"/>
  <object id="214" name="lake" type="lake" gid="22" x="96" y="320" width="32" height="32"/>
  <object id="215" name="lake" type="lake" gid="22" x="64" y="320" width="32" height="32"/>
  <object id="328" name="lake" type="lake" gid="22" x="160" y="352" width="32" height="32"/>
  <object id="329" name="lake" type="lake" gid="22" x="160" y="320" width="32" height="32"/>
  <object id="330" name="lake" type="lake" gid="22" x="512" y="288" width="32" height="32"/>
  <object id="331" name="lake" type="lake" gid="22" x="544" y="256" width="32" height="32"/>
  <object id="332" name="lake" type="lake" gid="22" x="512" y="256" width="32" height="32"/>
  <object id="333" name="lake" type="lake" gid="22" x="576" y="256" width="32" height="32"/>
  <object id="334" name="lake" type="lake" gid="22" x="544" y="224" width="32" height="32"/>
  <object id="335" name="lake" type="lake" gid="22" x="576" y="224" width="32" height="32"/>
  <object id="336" name="lake" type="lake" gid="22" x="544" y="288" width="32" height="32"/>
  <object id="337" name="lake" type="lake" gid="22" x="128" y="352" width="32" height="32"/>
  <object id="338" name="lake" type="lake" gid="22" x="224" y="512" width="32" height="32"/>
  <object id="339" name="lake" type="lake" gid="22" x="256" y="512" width="32" height="32"/>
  <object id="340" name="lake" type="lake" gid="22" x="256" y="480" width="32" height="32"/>
  <object id="341" name="lake" type="lake" gid="22" x="288" y="512" width="32" height="32"/>
  <object id="342" name="lake" type="lake" gid="22" x="288" y="544" width="32" height="32"/>
 </objectgroup>
 <objectgroup name="tanks">
  <object id="52" name="tank" type="tank" gid="20" x="576" y="544" width="32" height="32" rotation="-90">
   <properties>
    <property name="capacity" type="int" value="5"/>
    <property name="maxCapacity" type="int" value="8"/>
    <property name="maxPressure" type="int" value="7"/>
   </properties>
  </object>
  <object id="53" name="tank" type="tank" gid="20" x="192" y="576" width="32" height="32" rotation="-360">
   <properties>
    <property name="capacity" type="int" value="5"/>
    <property name="maxCapacity" type="int" value="8"/>
    <property name="maxPressure" type="int" value="7"/>
   </properties>
  </object>
  <object id="138" name="tank" type="tank" gid="20" x="672" y="384" width="32" height="32" rotation="-810">
   <properties>
    <property name="capacity" type="int" value="5"/>
    <property name="maxCapacity" type="int" value="8"/>
    <property name="maxPressure" type="int" value="7"/>
   </properties>
  </object>
  <object id="203" name="tank" type="tank" gid="20" x="288" y="96" width="32" height="32" rotation="-540">
   <properties>
    <property name="capacity" type="int" value="5"/>
    <property name="maxCapacity" type="int" value="8"/>
    <property name="maxPressure" type="int" value="7"/>
   </properties>
  </object>
  <object id="347" name="tank" type="tank" gid="20" x="544" y="64" width="32" height="32" rotation="-180">
   <properties>
    <property name="capacity" type="int" value="5"/>
    <property name="maxCapacity" type="int" value="8"/>
    <property name="maxPressure" type="int" value="7"/>
   </properties>
  </object>
  <object id="348" name="tank" type="tank" gid="20" x="224" y="352" width="32" height="32" rotation="-270">
   <properties>
    <property name="capacity" type="int" value="5"/>
    <property name="maxCapacity" type="int" value="8"/>
    <property name="maxPressure" type="int" value="7"/>
   </properties>
  </object>
 </objectgroup>
 <objectgroup name="turrets">
  <object id="204" name="turret" type="turret" gid="21" x="576" y="544" width="32" height="32" rotation="-90"/>
  <object id="205" name="turret" type="turret" gid="21" x="192" y="576" width="32" height="32" rotation="-360"/>
  <object id="206" name="turret" type="turret" gid="21" x="672" y="384" width="32" height="32" rotation="-810"/>
  <object id="207" name="turret" type="turret" gid="21" x="288" y="96" width="32" height="32" rotation="-540"/>
  <object id="349" name="turret" type="turret" gid="21" x="544" y="64" width="32" height="32" rotation="-180"/>
  <object id="350" name="turret" type="turret" gid="21" x="224" y="352" width="32" height="32" rotation="-270"/>
 </objectgroup>
 <objectgroup name="rocks">
  <object id="351" name="rock" type="rock" gid="23" x="640" y="480" width="32" height="32"/>
  <object id="352" name="rock" type="rock" gid="23" x="672" y="480" width="32" height="32"/>
  <object id="353" name="rock" type="rock" gid="23" x="640" y="448" width="32" height="32"/>
  <object id="354" name="rock" type="rock" gid="23" x="672" y="448" width="32" height="32"/>
  <object id="355" name="rock" type="rock" gid="23" x="320" y="384" width="32" height="32"/>
  <object id="356" name="rock" type="rock" gid="23" x="320" y="352" width="32" height="32"/>
  <object id="357" name="rock" type="rock" gid="23" x="288" y="320" width="32" height="32"/>
  <object id="358" name="rock" type="rock" gid="23" x="320" y="320" width="32" height="32"/>
  <object id="359" name="rock" type="rock" gid="23" x="288" y="288" width="32" height="32"/>
  <object id="360" name="rock" type="rock" gid="23" x="288" y="352" width="32" height="32"/>
  <object id="361" name="rock" type="rock" gid="23" x="320" y="512" width="32" height="32"/>
  <object id="362" name="rock" type="rock" gid="23" x="320" y="544" width="32" height="32"/>
  <object id="365" name="rock" type="rock" gid="23" x="448" y="160" width="32" height="32"/>
  <object id="366" name="rock" type="rock" gid="23" x="480" y="160" width="32" height="32"/>
  <object id="367" name="rock" type="rock" gid="23" x="480" y="128" width="32" height="32"/>
  <object id="368" name="rock" type="rock" gid="23" x="480" y="96" width="32" height="32"/>
  <object id="369" name="rock" type="rock" gid="23" x="512" y="64" width="32" height="32"/>
  <object id="370" name="rock" type="rock" gid="23" x="480" y="64" width="32" height="32"/>
  <object id="371" name="rock" type="rock" gid="23" x="480" y="416" width="32" height="32"/>
  <object id="372" name="rock" type="rock" gid="23" x="480" y="384" width="32" height="32"/>
  <object id="373" name="rock" type="rock" gid="23" x="512" y="384" width="32" height="32"/>
 </objectgroup>
 <objectgroup name="trees">
  <object id="147" name="tree" type="tree" gid="6" x="352" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="148" name="tree" type="tree" gid="6" x="384" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="149" name="tree" type="tree" gid="6" x="384" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="150" name="tree" type="tree" gid="6" x="384" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="151" name="tree" type="tree" gid="6" x="352" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="152" name="tree" type="tree" gid="6" x="352" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="153" name="tree" type="tree" gid="6" x="384" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="154" name="tree" type="tree" gid="6" x="416" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="155" name="tree" type="tree" gid="6" x="384" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="156" name="tree" type="tree" gid="6" x="416" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="157" name="tree" type="tree" gid="6" x="352" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="158" name="tree" type="tree" gid="6" x="384" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="159" name="tree" type="tree" gid="6" x="416" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="160" name="tree" type="tree" gid="6" x="352" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="161" name="tree" type="tree" gid="6" x="320" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="162" name="tree" type="tree" gid="6" x="320" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="163" name="tree" type="tree" gid="6" x="128" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="164" name="tree" type="tree" gid="6" x="96" y="512" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="165" name="tree" type="tree" gid="6" x="128" y="480" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="166" name="tree" type="tree" gid="6" x="128" y="512" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="167" name="tree" type="tree" gid="6" x="96" y="480" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="168" name="tree" type="tree" gid="6" x="64" y="480" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="169" name="tree" type="tree" gid="6" x="160" y="480" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="170" name="tree" type="tree" gid="6" x="96" y="544" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="171" name="tree" type="tree" gid="6" x="128" y="544" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="172" name="tree" type="tree" gid="6" x="352" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="173" name="tree" type="tree" gid="6" x="352" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="174" name="tree" type="tree" gid="6" x="384" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="175" name="tree" type="tree" gid="6" x="160" y="512" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="176" name="tree" type="tree" gid="6" x="64" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="177" name="tree" type="tree" gid="6" x="448" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="178" name="tree" type="tree" gid="6" x="416" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="179" name="tree" type="tree" gid="6" x="448" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="180" name="tree" type="tree" gid="6" x="96" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="181" name="tree" type="tree" gid="6" x="96" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="182" name="tree" type="tree" gid="6" x="128" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="183" name="tree" type="tree" gid="6" x="128" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="184" name="tree" type="tree" gid="6" x="96" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="185" name="tree" type="tree" gid="6" x="64" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="186" name="tree" type="tree" gid="6" x="64" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="187" name="tree" type="tree" gid="6" x="64" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="188" name="tree" type="tree" gid="6" x="64" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="189" name="tree" type="tree" gid="6" x="96" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="190" name="tree" type="tree" gid="6" x="96" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="191" name="tree" type="tree" gid="6" x="96" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="192" name="tree" type="tree" gid="6" x="128" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="193" name="tree" type="tree" gid="6" x="128" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="194" name="tree" type="tree" gid="6" x="64" y="512" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="195" name="tree" type="tree" gid="6" x="96" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="196" name="tree" type="tree" gid="6" x="128" y="672" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="197" name="tree" type="tree" gid="6" x="64" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="198" name="tree" type="tree" gid="6" x="352" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="199" name="tree" type="tree" gid="6" x="320" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="200" name="tree" type="tree" gid="6" x="320" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="201" name="tree" type="tree" gid="6" x="384" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="202" name="tree" type="tree" gid="6" x="416" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="217" name="tree" type="tree" gid="6" x="160" y="640" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="218" name="tree" type="tree" gid="6" x="160" y="672" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="219" name="tree" type="tree" gid="6" x="192" y="672" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="220" name="tree" type="tree" gid="6" x="224" y="640" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="221" name="tree" type="tree" gid="6" x="224" y="672" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="222" name="tree" type="tree" gid="6" x="224" y="704" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="223" name="tree" type="tree" gid="6" x="256" y="672" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="224" name="tree" type="tree" gid="6" x="256" y="640" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="225" name="tree" type="tree" gid="6" x="288" y="640" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="226" name="tree" type="tree" gid="6" x="288" y="672" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="227" name="tree" type="tree" gid="6" x="288" y="608" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="228" name="tree" type="tree" gid="6" x="256" y="608" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="229" name="tree" type="tree" gid="6" x="320" y="640" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="230" name="tree" type="tree" gid="6" x="320" y="672" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="231" name="tree" type="tree" gid="6" x="320" y="704" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="232" name="tree" type="tree" gid="6" x="352" y="704" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="233" name="tree" type="tree" gid="6" x="352" y="672" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="234" name="tree" type="tree" gid="6" x="352" y="640" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="235" name="tree" type="tree" gid="6" x="352" y="608" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="236" name="tree" type="tree" gid="6" x="384" y="608" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="237" name="tree" type="tree" gid="6" x="384" y="576" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="238" name="tree" type="tree" gid="6" x="416" y="576" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="239" name="tree" type="tree" gid="6" x="416" y="608" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="240" name="tree" type="tree" gid="6" x="384" y="640" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="241" name="tree" type="tree" gid="6" x="416" y="640" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="242" name="tree" type="tree" gid="6" x="416" y="672" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="243" name="tree" type="tree" gid="6" x="448" y="640" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="244" name="tree" type="tree" gid="6" x="448" y="672" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="245" name="tree" type="tree" gid="6" x="320" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="247" name="tree" type="tree" gid="6" x="320" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="248" name="tree" type="tree" gid="6" x="160" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="249" name="tree" type="tree" gid="6" x="160" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="250" name="tree" type="tree" gid="6" x="192" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="251" name="tree" type="tree" gid="6" x="160" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="252" name="tree" type="tree" gid="6" x="160" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="253" name="tree" type="tree" gid="6" x="128" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="254" name="tree" type="tree" gid="6" x="192" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="255" name="tree" type="tree" gid="6" x="96" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="256" name="tree" type="tree" gid="6" x="192" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="257" name="tree" type="tree" gid="6" x="192" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="258" name="tree" type="tree" gid="6" x="160" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="259" name="tree" type="tree" gid="6" x="192" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="260" name="tree" type="tree" gid="6" x="224" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="261" name="tree" type="tree" gid="6" x="224" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="262" name="tree" type="tree" gid="6" x="224" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="263" name="tree" type="tree" gid="6" x="128" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="264" name="tree" type="tree" gid="6" x="96" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="265" name="tree" type="tree" gid="6" x="64" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="266" name="tree" type="tree" gid="6" x="32" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="267" name="tree" type="tree" gid="6" x="32" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="268" name="tree" type="tree" gid="6" x="352" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="269" name="tree" type="tree" gid="6" x="384" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="270" name="tree" type="tree" gid="6" x="384" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="271" name="tree" type="tree" gid="6" x="416" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="272" name="tree" type="tree" gid="6" x="448" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="273" name="tree" type="tree" gid="6" x="416" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="274" name="tree" type="tree" gid="6" x="448" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="275" name="tree" type="tree" gid="6" x="384" y="480" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="276" name="tree" type="tree" gid="6" x="416" y="480" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="277" name="tree" type="tree" gid="6" x="448" y="480" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="278" name="tree" type="tree" gid="6" x="480" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="279" name="tree" type="tree" gid="6" x="512" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="280" name="tree" type="tree" gid="6" x="512" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="281" name="tree" type="tree" gid="6" x="480" y="480" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="282" name="tree" type="tree" gid="6" x="480" y="512" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="283" name="tree" type="tree" gid="6" x="512" y="480" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="284" name="tree" type="tree" gid="6" x="512" y="512" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="285" name="tree" type="tree" gid="6" x="544" y="480" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="286" name="tree" type="tree" gid="6" x="544" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="287" name="tree" type="tree" gid="6" x="544" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="288" name="tree" type="tree" gid="6" x="544" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="289" name="tree" type="tree" gid="6" x="576" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="290" name="tree" type="tree" gid="6" x="576" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="291" name="tree" type="tree" gid="6" x="576" y="608" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="292" name="tree" type="tree" gid="6" x="608" y="608" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="293" name="tree" type="tree" gid="6" x="640" y="608" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="294" name="tree" type="tree" gid="6" x="640" y="576" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="295" name="tree" type="tree" gid="6" x="608" y="576" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="296" name="tree" type="tree" gid="6" x="672" y="608" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="297" name="tree" type="tree" gid="6" x="608" y="640" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="298" name="tree" type="tree" gid="6" x="640" y="640" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="299" name="tree" type="tree" gid="6" x="672" y="640" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="300" name="tree" type="tree" gid="6" x="640" y="672" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="301" name="tree" type="tree" gid="6" x="672" y="672" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="302" name="tree" type="tree" gid="6" x="608" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="303" name="tree" type="tree" gid="6" x="608" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="304" name="tree" type="tree" gid="6" x="640" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="305" name="tree" type="tree" gid="6" x="672" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="306" name="tree" type="tree" gid="6" x="640" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="307" name="tree" type="tree" gid="6" x="608" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="308" name="tree" type="tree" gid="6" x="672" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="309" name="tree" type="tree" gid="6" x="640" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="310" name="tree" type="tree" gid="6" x="672" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="311" name="tree" type="tree" gid="6" x="640" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="312" name="tree" type="tree" gid="6" x="608" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="313" name="tree" type="tree" gid="6" x="608" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="314" name="tree" type="tree" gid="6" x="576" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="315" name="tree" type="tree" gid="6" x="576" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="316" name="tree" type="tree" gid="6" x="672" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="317" name="tree" type="tree" gid="6" x="640" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="318" name="tree" type="tree" gid="6" x="640" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="319" name="tree" type="tree" gid="6" x="672" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="320" name="tree" type="tree" gid="6" x="640" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="321" name="tree" type="tree" gid="6" x="672" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="322" name="tree" type="tree" gid="6" x="704" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="323" name="tree" type="tree" gid="6" x="704" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="324" name="tree" type="tree" gid="6" x="672" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="325" name="tree" type="tree" gid="6" x="608" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="326" name="tree" type="tree" gid="6" x="640" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="343" name="tree" type="tree" gid="6" x="352" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="344" name="tree" type="tree" gid="6" x="384" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="345" name="tree" type="tree" gid="6" x="416" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="346" name="tree" type="tree" gid="6" x="416" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
 </objectgroup>
</map>
', 2))

insert into MapModels values (NEWID(), CONVERT(XML, '<?xml version="1.0" encoding="UTF-8"?>
<map version="1.0" orientation="orthogonal" renderorder="right-down" width="20" height="16" tilewidth="32" tileheight="32" nextobjectid="327">
 <properties>
  <property name="algorithm" value=""/>
  <property name="wind" value="downright"/>
 </properties>
 <tileset firstgid="1" name="Sprites" tilewidth="32" tileheight="32" tilecount="25" columns="5">
  <image source="Sprites.png" width="160" height="160"/>
 </tileset>
 <layer name="terrain" width="20" height="16">
  <data>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="14"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="19"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="15"/>
   <tile gid="15"/>
   <tile gid="15"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="15"/>
   <tile gid="15"/>
   <tile gid="15"/>
   <tile gid="15"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="15"/>
   <tile gid="15"/>
   <tile gid="15"/>
   <tile gid="15"/>
   <tile gid="15"/>
   <tile gid="15"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="13"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="15"/>
   <tile gid="15"/>
   <tile gid="15"/>
   <tile gid="15"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
  </data>
 </layer>
 <objectgroup name="lakes">
  <object id="208" name="lake" type="lake" gid="22" x="448" y="192" width="32" height="32"/>
  <object id="209" name="lake" type="lake" gid="22" x="256" y="416" width="32" height="32"/>
  <object id="210" name="lake" type="lake" gid="22" x="224" y="352" width="32" height="32"/>
  <object id="211" name="lake" type="lake" gid="22" x="224" y="384" width="32" height="32"/>
  <object id="212" name="lake" type="lake" gid="22" x="256" y="384" width="32" height="32"/>
  <object id="213" name="lake" type="lake" gid="22" x="192" y="352" width="32" height="32"/>
  <object id="214" name="lake" type="lake" gid="22" x="160" y="352" width="32" height="32"/>
  <object id="215" name="lake" type="lake" gid="22" x="128" y="352" width="32" height="32"/>
  <object id="217" name="lake" type="lake" gid="22" x="480" y="192" width="32" height="32"/>
  <object id="218" name="lake" type="lake" gid="22" x="448" y="224" width="32" height="32"/>
  <object id="219" name="lake" type="lake" gid="22" x="480" y="224" width="32" height="32"/>
 </objectgroup>
 <objectgroup name="tanks">
  <object id="52" name="tank" type="tank" gid="20" x="512" y="384" width="32" height="32" rotation="-90">
   <properties>
    <property name="capacity" type="int" value="4"/>
    <property name="maxCapacity" type="int" value="5"/>
    <property name="maxPressure" type="int" value="5"/>
   </properties>
  </object>
  <object id="53" name="tank" type="tank" gid="20" x="320" y="448" width="32" height="32" rotation="-360">
   <properties>
    <property name="capacity" type="int" value="4"/>
    <property name="maxCapacity" type="int" value="5"/>
    <property name="maxPressure" type="int" value="5"/>
   </properties>
  </object>
  <object id="203" name="tank" type="tank" gid="20" x="160" y="224" width="32" height="32" rotation="-630">
   <properties>
    <property name="capacity" type="int" value="4"/>
    <property name="maxCapacity" type="int" value="5"/>
    <property name="maxPressure" type="int" value="5"/>
   </properties>
  </object>
 </objectgroup>
 <objectgroup name="turrets">
  <object id="322" name="turret" type="turret" gid="21" x="160" y="224" width="32" height="32" rotation="-270"/>
  <object id="323" name="turret" type="turret" gid="21" x="320" y="448" width="32" height="32" rotation="-360"/>
  <object id="324" name="turret" type="turret" gid="21" x="512" y="384" width="32" height="32" rotation="-90"/>
 </objectgroup>
 <objectgroup name="trees">
  <object id="148" name="tree" type="tree" gid="6" x="160" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="220" name="tree" type="tree" gid="6" x="192" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="221" name="tree" type="tree" gid="6" x="224" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="222" name="tree" type="tree" gid="6" x="192" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="223" name="tree" type="tree" gid="6" x="160" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="224" name="tree" type="tree" gid="6" x="128" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="225" name="tree" type="tree" gid="6" x="96" y="352" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="226" name="tree" type="tree" gid="6" x="96" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="227" name="tree" type="tree" gid="6" x="128" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="228" name="tree" type="tree" gid="6" x="160" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="229" name="tree" type="tree" gid="6" x="192" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="230" name="tree" type="tree" gid="6" x="224" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="231" name="tree" type="tree" gid="6" x="96" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="232" name="tree" type="tree" gid="6" x="64" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="233" name="tree" type="tree" gid="6" x="64" y="352" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="234" name="tree" type="tree" gid="6" x="96" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="235" name="tree" type="tree" gid="6" x="128" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="236" name="tree" type="tree" gid="6" x="64" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="237" name="tree" type="tree" gid="6" x="32" y="384" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="238" name="tree" type="tree" gid="6" x="64" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="239" name="tree" type="tree" gid="6" x="32" y="352" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="240" name="tree" type="tree" gid="6" x="32" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="241" name="tree" type="tree" gid="6" x="64" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="243" name="tree" type="tree" gid="6" x="96" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="244" name="tree" type="tree" gid="6" x="64" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="245" name="tree" type="tree" gid="6" x="128" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="246" name="tree" type="tree" gid="6" x="160" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="247" name="tree" type="tree" gid="6" x="192" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="248" name="tree" type="tree" gid="6" x="160" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="249" name="tree" type="tree" gid="6" x="192" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="250" name="tree" type="tree" gid="6" x="224" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="251" name="tree" type="tree" gid="6" x="224" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="252" name="tree" type="tree" gid="6" x="256" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="253" name="tree" type="tree" gid="6" x="256" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="254" name="tree" type="tree" gid="6" x="256" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="255" name="tree" type="tree" gid="6" x="224" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="256" name="tree" type="tree" gid="6" x="192" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="257" name="tree" type="tree" gid="6" x="160" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="258" name="tree" type="tree" gid="6" x="192" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="259" name="tree" type="tree" gid="6" x="224" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="260" name="tree" type="tree" gid="6" x="288" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="261" name="tree" type="tree" gid="6" x="288" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="262" name="tree" type="tree" gid="6" x="288" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="263" name="tree" type="tree" gid="6" x="96" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="264" name="tree" type="tree" gid="6" x="128" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="265" name="tree" type="tree" gid="6" x="160" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="266" name="tree" type="tree" gid="6" x="192" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="267" name="tree" type="tree" gid="6" x="352" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="268" name="tree" type="tree" gid="6" x="384" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="269" name="tree" type="tree" gid="6" x="416" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="270" name="tree" type="tree" gid="6" x="416" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="271" name="tree" type="tree" gid="6" x="416" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="272" name="tree" type="tree" gid="6" x="416" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="273" name="tree" type="tree" gid="6" x="448" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="274" name="tree" type="tree" gid="6" x="480" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="275" name="tree" type="tree" gid="6" x="480" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="276" name="tree" type="tree" gid="6" x="512" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="277" name="tree" type="tree" gid="6" x="512" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="278" name="tree" type="tree" gid="6" x="448" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="279" name="tree" type="tree" gid="6" x="416" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="280" name="tree" type="tree" gid="6" x="384" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="281" name="tree" type="tree" gid="6" x="384" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="282" name="tree" type="tree" gid="6" x="384" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="283" name="tree" type="tree" gid="6" x="416" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="284" name="tree" type="tree" gid="6" x="448" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="285" name="tree" type="tree" gid="6" x="480" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="286" name="tree" type="tree" gid="6" x="352" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="287" name="tree" type="tree" gid="6" x="384" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="289" name="tree" type="tree" gid="6" x="352" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="290" name="tree" type="tree" gid="6" x="416" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="291" name="tree" type="tree" gid="6" x="448" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="292" name="tree" type="tree" gid="6" x="480" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="293" name="tree" type="tree" gid="6" x="448" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="294" name="tree" type="tree" gid="6" x="480" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="295" name="tree" type="tree" gid="6" x="512" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="296" name="tree" type="tree" gid="6" x="512" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="297" name="tree" type="tree" gid="6" x="544" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="298" name="tree" type="tree" gid="6" x="544" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="299" name="tree" type="tree" gid="6" x="512" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="300" name="tree" type="tree" gid="6" x="416" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="301" name="tree" type="tree" gid="6" x="448" y="352" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="302" name="tree" type="tree" gid="6" x="480" y="352" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="303" name="tree" type="tree" gid="6" x="384" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="304" name="tree" type="tree" gid="6" x="416" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="305" name="tree" type="tree" gid="6" x="448" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="306" name="tree" type="tree" gid="6" x="480" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="307" name="tree" type="tree" gid="6" x="416" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="308" name="tree" type="tree" gid="6" x="448" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="309" name="tree" type="tree" gid="6" x="480" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="310" name="tree" type="tree" gid="6" x="512" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="311" name="tree" type="tree" gid="6" x="512" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="312" name="tree" type="tree" gid="6" x="544" y="416" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="313" name="tree" type="tree" gid="6" x="448" y="480" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="314" name="tree" type="tree" gid="6" x="480" y="480" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="315" name="tree" type="tree" gid="6" x="448" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="316" name="tree" type="tree" gid="6" x="480" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="317" name="tree" type="tree" gid="6" x="512" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="318" name="tree" type="tree" gid="6" x="544" y="448" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="319" name="tree" type="tree" gid="6" x="256" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="320" name="tree" type="tree" gid="6" x="288" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="321" name="tree" type="tree" gid="6" x="224" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="325" name="tree" type="tree" gid="6" x="256" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="326" name="tree" type="tree" gid="6" x="288" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
 </objectgroup>
</map>
', 2))

insert into MapModels values (NEWID(), CONVERT(XML, '<?xml version="1.0" encoding="UTF-8"?>
<map version="1.0" orientation="orthogonal" renderorder="right-down" width="8" height="8" tilewidth="32" tileheight="32" nextobjectid="187">
 <properties>
  <property name="algorithm" value=""/>
  <property name="wind" value="right"/>
 </properties>
 <tileset firstgid="1" name="Sprites" tilewidth="32" tileheight="32" tilecount="25" columns="5">
  <image source="Sprites.png" width="160" height="160"/>
 </tileset>
 <layer name="terrain" width="8" height="8">
  <data>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
  </data>
 </layer>
 <objectgroup name="tanks">
  <object id="138" name="tank" type="tank" gid="20" x="32" y="96" width="32" height="32" rotation="-270">
   <properties>
    <property name="capacity" type="int" value="5"/>
    <property name="maxCapacity" type="int" value="5"/>
    <property name="maxPressure" type="int" value="5"/>
   </properties>
  </object>
 </objectgroup>
 <objectgroup name="turrets">
  <object id="139" name="turret" type="turret" gid="21" x="32" y="96" width="32" height="32" rotation="-270"/>
 </objectgroup>
 <objectgroup name="trees">
  <object id="165" name="tree" type="tree" gid="6" x="128" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="166" name="tree" type="tree" gid="6" x="96" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="167" name="tree" type="tree" gid="6" x="224" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="168" name="tree" type="tree" gid="6" x="160" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="169" name="tree" type="tree" gid="6" x="192" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="170" name="tree" type="tree" gid="6" x="160" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="171" name="tree" type="tree" gid="6" x="224" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="172" name="tree" type="tree" gid="6" x="192" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="173" name="tree" type="tree" gid="6" x="192" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="174" name="tree" type="tree" gid="6" x="160" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="175" name="tree" type="tree" gid="6" x="128" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="176" name="tree" type="tree" gid="6" x="192" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="177" name="tree" type="tree" gid="6" x="160" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="178" name="tree" type="tree" gid="6" x="192" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="179" name="tree" type="tree" gid="6" x="96" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="180" name="tree" type="tree" gid="6" x="160" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="181" name="tree" type="tree" gid="6" x="224" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="182" name="tree" type="tree" gid="6" x="224" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="183" name="tree" type="tree" gid="6" x="192" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="184" name="tree" type="tree" gid="6" x="128" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="185" name="tree" type="tree" gid="6" x="96" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="186" name="tree" type="tree" gid="6" x="128" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
 </objectgroup>
</map>
', 2))

insert into MapModels values (NEWID(), CONVERT(XML, '<?xml version="1.0" encoding="UTF-8"?>
<map version="1.0" orientation="orthogonal" renderorder="right-down" width="12" height="12" tilewidth="32" tileheight="32" nextobjectid="156">
 <properties>
  <property name="algorithm" value="TrainingExample.fta2"/>
  <property name="wind" value="up"/>
 </properties>
 <tileset firstgid="1" name="Sprites" tilewidth="32" tileheight="32" tilecount="25" columns="5">
  <image source="Sprites.png" width="160" height="160"/>
 </tileset>
 <layer name="terrain" width="12" height="12">
  <data>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
   <tile gid="12"/>
  </data>
 </layer>
 <objectgroup name="tanks">
  <object id="138" name="tank" type="tank" gid="20" x="160" y="288" width="32" height="32" rotation="-360">
   <properties>
    <property name="capacity" type="int" value="3"/>
    <property name="maxCapacity" type="int" value="10"/>
    <property name="maxPressure" type="int" value="5"/>
   </properties>
  </object>
  <object id="155" name="tank" type="tank" gid="20" x="320" y="192" width="32" height="32" rotation="-450">
   <properties>
    <property name="capacity" type="int" value="3"/>
    <property name="maxCapacity" type="int" value="10"/>
    <property name="maxPressure" type="int" value="5"/>
   </properties>
  </object>
 </objectgroup>
 <objectgroup name="turrets">
  <object id="139" name="turret" type="turret" gid="21" x="160" y="288" width="32" height="32" rotation="-360"/>
  <object id="148" name="turret" type="turret" gid="21" x="320" y="192" width="32" height="32" rotation="-450"/>
 </objectgroup>
 <objectgroup name="trees">
  <object id="78" name="tree" type="tree" gid="6" x="64" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="80" name="tree" type="tree" gid="6" x="64" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="81" name="tree" type="tree" gid="6" x="128" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="83" name="tree" type="tree" gid="6" x="96" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="84" name="tree" type="tree" gid="6" x="96" y="192" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="86" name="tree" type="tree" gid="6" x="64" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="87" name="tree" type="tree" gid="6" x="128" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="92" name="tree" type="tree" gid="6" x="96" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="93" name="tree" type="tree" gid="6" x="64" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="94" name="tree" type="tree" gid="6" x="96" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="117" name="tree" type="tree" gid="6" x="160" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="118" name="tree" type="tree" gid="6" x="256" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="120" name="tree" type="tree" gid="6" x="256" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="121" name="tree" type="tree" gid="6" x="224" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="122" name="tree" type="tree" gid="6" x="224" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="123" name="tree" type="tree" gid="6" x="224" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="124" name="tree" type="tree" gid="6" x="160" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="125" name="tree" type="tree" gid="6" x="320" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="126" name="tree" type="tree" gid="6" x="128" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="127" name="tree" type="tree" gid="6" x="192" y="160" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="128" name="tree" type="tree" gid="6" x="192" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="129" name="tree" type="tree" gid="6" x="288" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="131" name="tree" type="tree" gid="6" x="224" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="132" name="tree" type="tree" gid="6" x="160" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="133" name="tree" type="tree" gid="6" x="320" y="224" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="135" name="tree" type="tree" gid="6" x="224" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="136" name="tree" type="tree" gid="6" x="288" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="137" name="tree" type="tree" gid="6" x="192" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="140" name="tree" type="tree" gid="6" x="256" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="141" name="tree" type="tree" gid="6" x="288" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="142" name="tree" type="tree" gid="6" x="256" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="true"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="143" name="tree" type="tree" gid="6" x="288" y="96" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="144" name="tree" type="tree" gid="6" x="256" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="145" name="tree" type="tree" gid="6" x="288" y="128" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="146" name="tree" type="tree" gid="6" x="192" y="64" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="149" name="tree" type="tree" gid="6" x="32" y="256" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="150" name="tree" type="tree" gid="6" x="32" y="288" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="151" name="tree" type="tree" gid="6" x="64" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
  <object id="152" name="tree" type="tree" gid="6" x="96" y="320" width="32" height="32">
   <properties>
    <property name="burns" type="bool" value="false"/>
    <property name="hitpoints" type="int" value="10"/>
   </properties>
  </object>
 </objectgroup>
</map>
', 2))
