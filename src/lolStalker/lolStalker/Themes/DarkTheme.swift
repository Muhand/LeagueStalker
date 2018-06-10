//
//  DarkTheme.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/9/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import UIKit

class DarkTheme: Theme {
    override init(themeName: String) {
        super.init(themeName: themeName)
        self.mainColor = UIColor(hex: "#010A13");
        self.logo = UIImage(named: "logo")
    }
}
