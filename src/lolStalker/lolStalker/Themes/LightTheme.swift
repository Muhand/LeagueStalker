//
//  LightTheme.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/9/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import UIKit

class LightTheme: Theme {
    override init(themeName: String) {
        super.init(themeName: themeName)
        self.mainColor = UIColor.blue
        self.logo = UIImage(named: "logo")
    }
}
