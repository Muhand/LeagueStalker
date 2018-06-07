//
//  DashboardViewController.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/6/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation
import UIKit

class DashboardViewController: UITabBarController {
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    
    
    ////////// END OF CONTROLS /////////
    override func viewDidLoad() {
        super.viewDidLoad()
        print("Dashboard")
        setupView()
        setupTabs()
        setupSubViews()
        setupConstraints()
        setupMargins()
    }
    
    func setupView() {
        hideKeyboardWhenTappedAround()
        selectedIndex = 1
        view.backgroundColor = UIColor(hex: "#010A13")
        tabBar.barTintColor = UIColor(hex: "#010A13")
        // Disable this for a blurred background
        tabBar.isTranslucent = false
        tabBar.addBorder(toSide: .Top, withColor: (UIColor(hex: "#95989A")?.cgColor)!, andThickness: 1.0)
        view.tintColor = UIColor.white
    }
    
    func setupTabs() {
        let historyViewController = HistoryViewController()
        historyViewController.tabBarItem = UITabBarItem(title: "History", image: #imageLiteral(resourceName: "history"), tag: 0)
        
        let homeViewController = HomeViewController()
        homeViewController.tabBarItem = UITabBarItem(title: "Home", image: #imageLiteral(resourceName: "home"), tag: 1)
        
        let settingsViewController = SettingsViewController()
        settingsViewController.tabBarItem = UITabBarItem(title: "Settings", image: #imageLiteral(resourceName: "settings"), tag: 2)
        
        let viewControllerList = [ historyViewController, homeViewController, settingsViewController ]
        viewControllers = viewControllerList
    }
    
    func setupSubViews() {
        
    }
    
    func setupConstraints() {
        
    }
    
    func setupMargins() {
    }
    
    override func viewWillTransition(to size: CGSize, with coordinator: UIViewControllerTransitionCoordinator) {
        super.viewWillTransition(to: size, with: coordinator)
        view.setNeedsDisplay()
    }
}
